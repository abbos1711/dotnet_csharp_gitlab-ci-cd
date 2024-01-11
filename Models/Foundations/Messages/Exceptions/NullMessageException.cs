using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class NullMessageException : Xeption
    {
        public NullMessageException() : base(message: "Message is null!")
        { }
    }
}
