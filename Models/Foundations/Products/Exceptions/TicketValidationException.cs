using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class ProductValidationException : Xeption
    {
        public ProductValidationException(Xeption innerException)
            : base(message: "Product validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
