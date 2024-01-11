using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class FailedProductServiceException : Xeption
    {
        public FailedProductServiceException(Exception innerException)
            : base(message: "Failed Product service error occurred, please contact support", innerException)
        { }
    }
}
