using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class InvalidProductReferenceException : Xeption
    {
        public InvalidProductReferenceException(Exception innerException)
            : base(message: "Invalid Product reference error occurred.", innerException)
        { }
    }
}
