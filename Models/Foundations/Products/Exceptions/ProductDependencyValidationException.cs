using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class ProductDependencyValidationException : Xeption
    {
        public ProductDependencyValidationException(Xeption innerException)
            : base(message: "Product dependency validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
