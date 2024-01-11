using System;
using Microsoft.AspNetCore.Http;

namespace dosLogistic.API.Models.Foundations.Products
{
    public class ProductAdminSideCreation
    {
        public Guid Id { get; set; }
        public decimal? Weight { get; set; }
        public decimal? ServicePrice { get; set; }
        public ProductStatus? ProductStatus { get; set; }
        public IFormFile Image { get; set; }
    }
}
