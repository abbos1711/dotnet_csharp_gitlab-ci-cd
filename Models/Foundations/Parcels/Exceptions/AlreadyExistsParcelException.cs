using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Parcels.Exceptions
{
    public class AlreadyExistsParcelException : Xeption
    {
        public AlreadyExistsParcelException(Exception innerException)
            : base(message: "Parcel already exists.", innerException)
        { }
    }
}
