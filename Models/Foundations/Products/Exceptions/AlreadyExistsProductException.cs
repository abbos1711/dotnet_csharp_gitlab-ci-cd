using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class AlreadyExistsProductException : Xeption
    {
        public AlreadyExistsProductException(Exception innerException)
            : base(message: "Product already exists.", innerException)
        { }
    }
}
