using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Brokers.DataTimes;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Brokers.Storages;
using dosLogistic.API.Models.Foundations.Products;
using dosLogistic.API.Services.Processings.CurrentUserDetails;
using Microsoft.AspNetCore.Hosting;

namespace dosLogistic.API.Services.Foundatioins.Products
{
    public partial class ProductService : IProductService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker,
            IWebHostEnvironment webHostEnvironment)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
            this.webHostEnvironment = webHostEnvironment;
        }

        public ValueTask<Product> AddProductAsync(ProductCreation productCreation) =>
        TryCatch(async () =>
        {
            var product = (Product)productCreation;

            ValidateProductOnAdd(product);

            return await this.storageBroker.InsertProductAsync(product);
        });

        public IQueryable<Product> RetrieveAllProducts() =>
        TryCatch(() => this.storageBroker.SelectAllProducts());

        public IQueryable<Product> RetrieveAllProductsByUserId()
        {
            Guid userId = CurrentUserDetaile.UserId();
            return TryCatch(() => this.storageBroker.SelectAllProducts()
                    .Where(x => x.UserId == userId));
        }

        public ValueTask<Product> RetrieveProductByIdAsync(Guid productId) =>
        TryCatch(async () =>
        {
            ValidateProductId(productId);

            Product maybeProduct =
                await this.storageBroker.SelectProductByIdAsync(productId);

            ValidateStorageProduct(maybeProduct, productId);

            return maybeProduct;
        });

        public ValueTask<Product> ModifyProductAsync(ProductCreation productCreation) =>
        TryCatch(async () =>
        {
            var product = (Product)productCreation;

            ValidateProductOnModify(product);
            var maybeProduct = await this.storageBroker.SelectProductByIdAsync(product.Id);


            ValidateStorageProduct(maybeProduct, product.Id);
            ValidateAginstStorageProductOnModify(inputProduct: product, storageProduct: maybeProduct);

            product.Weight = maybeProduct.Weight;
            product.ServicePrice = maybeProduct.ServicePrice;
            product.ImgUrl = maybeProduct.ImgUrl;

            return await this.storageBroker.UpdateProductAsync(product);
        });

        public ValueTask<Product> AddOrModifyProductByAdminAsync(ProductAdminSideCreation adminSideCreation) =>
        TryCatch(async () =>
        {
            var maybeProduct = await this.storageBroker.SelectProductByIdAsync(adminSideCreation.Id);

            await ProductAdminCreationsManagerAsync(maybeProduct, adminSideCreation);
            await this.storageBroker.UpdateProductAsync(maybeProduct);

            return maybeProduct;
        });

        public ValueTask<Product> RemoveProductByIdAsync(Guid productId) =>
        TryCatch(async () =>
        {
            ValidateProductId(productId);

            Product maybeProduct = await this.storageBroker
                .SelectProductByIdAsync(productId);

            ValidateStorageProduct(maybeProduct, productId);

            return await this.storageBroker.DeleteProductAsync(maybeProduct);
        });
    }
}
