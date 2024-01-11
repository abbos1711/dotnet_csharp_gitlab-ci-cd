using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class ParcelDependencyException : Xeption
    {
        public ParcelDependencyException(Xeption innerException)
            : base(message: "Parcel dependency error occurred, contact support.", innerException)
        { }
    }
}
