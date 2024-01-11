using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class InvalidParcelException : Xeption
    {
        public InvalidParcelException()
            : base(message: "Parcel is invalid.")
        { }
    }
}
