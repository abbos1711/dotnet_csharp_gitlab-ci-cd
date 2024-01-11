using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class ParcelServiceException : Xeption
    {
        public ParcelServiceException(Exception innerException)
            : base(message: "Parcel service error occurred, contact support.", innerException)
        { }
    }
}
