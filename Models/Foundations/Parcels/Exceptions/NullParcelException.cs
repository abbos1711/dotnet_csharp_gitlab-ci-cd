using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class NullParcelException : Xeption
    {
        public NullParcelException() : base(message: "Parcel is null.")
        { }
    }
}
