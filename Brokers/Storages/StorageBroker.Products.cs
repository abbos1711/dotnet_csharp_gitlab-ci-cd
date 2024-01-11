﻿using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Products;
using Microsoft.EntityFrameworkCore;

namespace dosLogistic.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Product> Products { get; set; }

        public async ValueTask<Product> InsertProductAsync(Product product) =>
            await InsertAsync(product);

        public IQueryable<Product> SelectAllProducts() =>
            SelectAll<Product>();

        public async ValueTask<Product> SelectProductByIdAsync(Guid id) =>
            await SelectAsync<Product>(id);

        public async ValueTask<Product> UpdateProductAsync(Product product) =>
            await UpdateAsync(product);

        public async ValueTask<Product> DeleteProductAsync(Product product) =>
            await DeleteAsync(product);
    }
}
