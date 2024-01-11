using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class LockedProductException : Xeption
    {
        public LockedProductException(Exception innerException)
            : base(message: "Product is locked, please try again.", innerException)
        { }
    }
}
