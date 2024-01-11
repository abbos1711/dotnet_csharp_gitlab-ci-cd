using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class ParcelValidationException : Xeption
    {
        public ParcelValidationException(Xeption innerException)
            : base(message: "Parcel validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
