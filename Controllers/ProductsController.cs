using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using dosLogistic.API.Models.Foundations.Products;
using dosLogistic.API.Models.Foundations.Products.Exceptions;
using dosLogistic.API.Services.Foundatioins.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RESTFulSense.Controllers;

namespace dosLogistic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : RESTFulController
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService) =>
        this.productService = productService;

        [HttpPost]
        [Authorize(Roles = "User")]
        public async ValueTask<ActionResult<Product>> PostProductAsync(ProductCreation product)
        {
            try
            {
                return await this.productService.AddProductAsync(product);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException.InnerException);
            }
            catch (ProductDependencyValidationException productDependencyValidationException)
                when (productDependencyValidationException.InnerException is AlreadyExistsProductException)
            {
                return Conflict(productDependencyValidationException.InnerException);
            }
            catch (ProductDependencyValidationException productDependencyValidationException)
            {
                return BadRequest(productDependencyValidationException.InnerException);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException.InnerException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException.InnerException);
            }
        }

        [HttpGet("GetAllProducts")]
        [EnableQuery]
        [Authorize(Roles = "GermanAdmin,PolandAdmin,Admin,SuperAdmin")]
        public ActionResult<IQueryable<Product>> GetAllProducts()
        {
            try
            {
                IQueryable<Product> allProducts = this.productService.RetrieveAllProducts();

                return Ok(allProducts);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException.InnerException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException.InnerException);
            }
        }

        [HttpGet("GetProductsByUserId")]
        [EnableQuery]
        [Authorize]
        public ActionResult<IQueryable<Product>> GetProductsByUserId()
        {
            try
            {
                IQueryable<Product> allProducts = this.productService.RetrieveAllProductsByUserId();

                return Ok(allProducts);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException.InnerException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException.InnerException);
            }
        }

        [HttpGet("GetUserProductsAsExcel")]
        [EnableQuery]
        [Authorize]
        public ActionResult<IQueryable<Product>> GetUserProductsAsExcel()
        {
            try
            {
                var products = this.productService.RetrieveAllProductsByUserId();
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Products");
                    var currentRow = 1;

                    #region Header
                    worksheet.Cell(currentRow, 1).Value = "Product Id";
                    worksheet.Cell(currentRow, 2).Value = "Tracking Id";
                    worksheet.Cell(currentRow, 3).Value = "Shop Name";
                    worksheet.Cell(currentRow, 4).Value = "Product Price";
                    worksheet.Cell(currentRow, 5).Value = "Product Status";
                    worksheet.Cell(currentRow, 6).Value = "Amount";
                    worksheet.Cell(currentRow, 7).Value = "Weight";
                    worksheet.Cell(currentRow, 8).Value = "ServicePrice";
                    worksheet.Cell(currentRow, 9).Value = "Image Url";
                    #endregion

                    #region Body
                    int number = 1;
                    foreach (var student in products)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = number++;
                        worksheet.Cell(currentRow, 2).Value = student.TrackingId;
                        worksheet.Cell(currentRow, 3).Value = student.ShopName;
                        worksheet.Cell(currentRow, 4).Value = student.ProductPrice;
                        worksheet.Cell(currentRow, 5).Value = student.ProductStatus.ToString();
                        worksheet.Cell(currentRow, 6).Value = student.Amount;
                        worksheet.Cell(currentRow, 7).Value = student.Weight;
                        worksheet.Cell(currentRow, 8).Value = student.ServicePrice;
                        worksheet.Cell(currentRow, 9).Value = student.ImgUrl;

                    }
                    #endregion

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();

                        return File(
                            content,
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "Products.xlsx"
                            );
                    }
                }
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException.InnerException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException.InnerException);
            }
        }

        [HttpGet("{productId}")]
        [Authorize]
        public async ValueTask<ActionResult<Product>> GetProductByIdAsync(Guid productId)
        {
            try
            {
                return await this.productService.RetrieveProductByIdAsync(productId);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException.InnerException);
            }
            catch (ProductValidationException productValidationException)
                when (productValidationException.InnerException is InvalidProductException)
            {
                return BadRequest(productValidationException.InnerException);
            }
            catch (ProductValidationException productValidationException)
                when (productValidationException.InnerException is NotFoundProductException)
            {
                return NotFound(productValidationException.InnerException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException.InnerException);
            }
        }

        [HttpPut]
        [Authorize(Roles = "GermanAdmin,PolandAdmin,Admin,SuperAdmin")]
        public async ValueTask<ActionResult<Product>> PutProductAsync(ProductCreation product)
        {
            try
            {
                Product modifiedProduct =
                    await this.productService.ModifyProductAsync(product);

                return Ok(modifiedProduct);
            }
            catch (ProductValidationException productValidationException)
                when (productValidationException.InnerException is NotFoundProductException)
            {
                return NotFound(productValidationException.InnerException);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException.InnerException);
            }
            catch (ProductDependencyValidationException productDependencyValidationException)
            {
                return BadRequest(productDependencyValidationException.InnerException);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException.InnerException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException.InnerException);
            }
        }

        [HttpPatch("adminCreationsForProduct")]
        [Authorize(Roles = "GermanAdmin,PolandAdmin,Admin,SuperAdmin")]
        public async ValueTask<ActionResult<Product>> PatchProductAdminCreationAsync([FromForm] ProductAdminSideCreation adminCreations)
        {
            try
            {
                Product modifiedProduct =
                    await this.productService.AddOrModifyProductByAdminAsync(adminCreations);

                return Ok(modifiedProduct);
            }
            catch (ProductValidationException productValidationException)
                when (productValidationException.InnerException is NotFoundProductException)
            {
                return NotFound(productValidationException.InnerException);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException.InnerException);
            }
            catch (ProductDependencyValidationException productDependencyValidationException)
            {
                return BadRequest(productDependencyValidationException.InnerException);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException.InnerException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException.InnerException);
            }
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async ValueTask<ActionResult<Product>> DeleteProductByIdAsync(Guid productId)
        {
            try
            {
                Product deletedProduct =
                    await this.productService.RemoveProductByIdAsync(productId);

                return Ok(deletedProduct);
            }
            catch (ProductValidationException productValidationException)
                when (productValidationException.InnerException is NotFoundProductException)
            {
                return NotFound(productValidationException.InnerException);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException.InnerException);
            }
            catch (ProductDependencyValidationException productDependencyValidationException)
                when (productDependencyValidationException.InnerException is LockedProductException)
            {
                return Locked(productDependencyValidationException.InnerException);
            }
            catch (ProductDependencyValidationException productDependencyValidationException)
            {
                return BadRequest(productDependencyValidationException.InnerException);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException.InnerException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException.InnerException);
            }
        }
    }
}
