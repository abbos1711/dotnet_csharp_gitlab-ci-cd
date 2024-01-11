using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class InvalidMessageException : Xeption
    {
        public InvalidMessageException() : base(message: "Message is invalid!")
        { }
    }
}
