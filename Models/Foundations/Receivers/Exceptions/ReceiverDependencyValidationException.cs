using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class ReceiverDependencyValidationException : Xeption
    {
        public ReceiverDependencyValidationException(Xeption innerException)
            : base(message: "Receiver dependency validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
