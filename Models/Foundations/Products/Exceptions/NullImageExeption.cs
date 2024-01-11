using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class NullImageExeption : Xeption
    {
        public NullImageExeption() : base(message: "Image is null!")
        { }
    }
}
