using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class InvalidProductException : Xeption
    {
        public InvalidProductException()
            : base(message: "Product is invalid.")
        { }
    }
}
