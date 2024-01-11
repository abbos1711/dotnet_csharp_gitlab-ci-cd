using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class ProductServiceException : Xeption
    {
        public ProductServiceException(Exception innerException)
            : base(message: "Product service error occurred, contact support.", innerException)
        { }
    }
}
