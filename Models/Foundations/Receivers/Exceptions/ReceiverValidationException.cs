using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class ReceiverValidationException : Xeption
    {
        public ReceiverValidationException(Xeption innerException)
            : base(message: "Receiver validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
