using System;
using dosLogistic.API.Services.Processings.CurrentUserDetails;

namespace dosLogistic.API.Models.Foundations.Products
{
    public class ProductCreation
    {
        public Guid Id { get; set; }
        public string TrackingId { get; set; }
        public string ShopName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Amount { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid ReceiverId { get; set; }

        public static implicit operator Product(ProductCreation newProduct)
        {
            return new Product()
            {
                Id = newProduct.Id,
                TrackingId = newProduct.TrackingId,
                ShopName = newProduct.ShopName,
                ProductPrice = newProduct.ProductPrice,
                Amount = newProduct.Amount,
                CreatedDate = newProduct.CreatedDate,
                UpdatedDate = newProduct.UpdatedDate,
                ReceiverId = newProduct.ReceiverId,
                UserId = CurrentUserDetaile.UserId()
            };
        }
    }

}
