using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class FailedProductStorageException : Xeption
    {
        public FailedProductStorageException(Exception innerException)
            : base(message: "Failed Product storage error occurred, contact support.", innerException)
        { }
    }
}
