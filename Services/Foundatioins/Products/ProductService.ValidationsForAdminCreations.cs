using System;
using System.IO;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Products;

namespace dosLogistic.API.Services.Foundatioins.Products
{
    public partial class ProductService
    {
        private async Task ProductAdminCreationsManagerAsync(Product product, ProductAdminSideCreation adminCreations)
        {
            if (adminCreations.Image is not null)
            {
                var file = adminCreations.Image;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string wwwrootPath = webHostEnvironment.WebRootPath;
                string filePath = Path.Combine(wwwrootPath, "uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                product.ImgUrl = filePath;
            }

            product.ServicePrice = (adminCreations.ServicePrice is not null) ? adminCreations.ServicePrice : product.ServicePrice;
            product.Weight = (adminCreations.Weight is not null) ? adminCreations.Weight : product.Weight;
            product.ProductStatus = (adminCreations.ProductStatus is null) ? product.ProductStatus : adminCreations.ProductStatus.Value;
        }
    }
}
