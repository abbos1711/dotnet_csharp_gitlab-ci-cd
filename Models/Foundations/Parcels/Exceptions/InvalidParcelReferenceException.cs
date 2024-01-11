using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class InvalidParcelReferenceException : Xeption
    {
        public InvalidParcelReferenceException(Exception innerException)
            : base(message: "Invalid parcel reference error occurred.", innerException)
        { }
    }
}
