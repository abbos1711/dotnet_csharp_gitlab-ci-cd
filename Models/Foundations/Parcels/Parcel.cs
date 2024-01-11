using System;
using System.Text.Json.Serialization;
using dosLogistic.API.Models.Foundations.Receivers;
using dosLogistic.API.Models.Foundations.Senders;
using dosLogistic.API.Models.Foundations.Users;

namespace dosLogistic.API.Models.Foundations.Parcels
{
    public class Parcel
    {
        public Guid Id { get; set; }
        public string ParcelName { get; set; }
        public string ProductName { get; set; }
        public ParcelCountry ParcelCountry { get; set; }
        public decimal? ServicePrice { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public ParcelStatus ParcelStatus { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Guid SenderId { get; set; }
        [JsonIgnore]
        public Sender Sender { get; set; }
        public Guid ReceiverId { get; set; }
        [JsonIgnore]
        public Receiver Receiver { get; set; }
    }
}
