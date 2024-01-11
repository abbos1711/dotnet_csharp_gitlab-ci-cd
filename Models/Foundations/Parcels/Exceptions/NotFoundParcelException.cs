using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class NotFoundParcelException : Xeption
    {
        public NotFoundParcelException(Guid ticketId)
            : base(message: $"Couldn't find parcel with id: {ticketId}.")
        { }
    }
}
