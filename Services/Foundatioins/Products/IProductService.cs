using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Products;

namespace dosLogistic.API.Services.Foundatioins.Products
{
    public interface IProductService
    {
        ValueTask<Product> AddProductAsync(ProductCreation productCreation);
        IQueryable<Product> RetrieveAllProducts();
        IQueryable<Product> RetrieveAllProductsByUserId();
        ValueTask<Product> RetrieveProductByIdAsync(Guid productId);
        ValueTask<Product> ModifyProductAsync(ProductCreation productCreation);
        ValueTask<Product> AddOrModifyProductByAdminAsync(ProductAdminSideCreation adminCreations);
        ValueTask<Product> RemoveProductByIdAsync(Guid productId);
    }
}
