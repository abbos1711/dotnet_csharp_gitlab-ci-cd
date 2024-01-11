using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class MessageValidationException : Xeption
    {
        public MessageValidationException(Xeption innerException)
            : base(message: "Message validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
