using System;
using System.Text.Json.Serialization;
using dosLogistic.API.Models.Foundations.Receivers;
using dosLogistic.API.Models.Foundations.Users;

namespace dosLogistic.API.Models.Foundations.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string TrackingId { get; set; }
        public string ShopName { get; set; }
        public decimal ProductPrice { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public int Amount { get; set; }
        public decimal? Weight { get; set; }
        public decimal? ServicePrice { get; set; }
        public string? ImgUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public Guid ReceiverId { get; set; }
        [JsonIgnore]
        public Receiver Receiver { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
