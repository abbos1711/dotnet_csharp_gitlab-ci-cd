using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class SenderValidationException : Xeption
    {
        public SenderValidationException(Xeption innerException)
            : base(message: "Sender validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
