using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class FailedParcelStorageException : Xeption
    {
        public FailedParcelStorageException(Exception innerException)
            : base(message: "Failed parcel storage error occurred, contact support.", innerException)
        { }
    }
}
