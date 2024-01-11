using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class ParcelDependencyValidationException : Xeption
    {
        public ParcelDependencyValidationException(Xeption innerException)
            : base(message: "Parcel dependency validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
