using System;

namespace dosLogistic.API.Models.Foundations.Parcels
{
    public class ParcelAdminCreation
    {
        public Guid Id { get; set; }
        public ParcelStatus? ParcelStatus { get; set; }
        public decimal? ServicePrice { get; set; }
    }
}
