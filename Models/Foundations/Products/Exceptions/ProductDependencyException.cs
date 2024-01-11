﻿using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class ProductDependencyException : Xeption
    {
        public ProductDependencyException(Xeption innerException)
            : base(message: "Product dependency error occurred, contact support.", innerException)
        { }
    }
}
