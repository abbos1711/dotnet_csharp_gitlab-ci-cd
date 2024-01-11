using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class FailedParcelServiceException : Xeption
    {
        public FailedParcelServiceException(Exception innerException)
            : base(message: "Failed parcel service error occurred, please contact support", innerException)
        { }
    }
}
