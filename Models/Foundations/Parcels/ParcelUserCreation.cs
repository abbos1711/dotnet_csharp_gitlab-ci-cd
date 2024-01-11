using System;
using dosLogistic.API.Services.Processings.CurrentUserDetails;

namespace dosLogistic.API.Models.Foundations.Parcels
{
    public class ParcelUserCreation
    {
        public Guid Id { get; set; }
        public string ParcelName { get; set; }
        public string ProductName { get; set; }
        public ParcelCountry ParcelCountry { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }

        public static implicit operator Parcel(ParcelUserCreation parcelUserCreation)
        {
            return new Parcel
            {
                Id = parcelUserCreation.Id,
                ParcelName = parcelUserCreation.ParcelName,
                ProductName = parcelUserCreation.ProductName,
                ParcelCountry = parcelUserCreation.ParcelCountry,
                ImageUrl = parcelUserCreation.ImageUrl,
                Description = parcelUserCreation.Description,
                Amount = parcelUserCreation.Amount,
                Comment = parcelUserCreation.Comment,
                UserId = CurrentUserDetaile.UserId(),
                SenderId = parcelUserCreation.SenderId,
                ReceiverId = parcelUserCreation.ReceiverId,
            };
        }
    }
}
