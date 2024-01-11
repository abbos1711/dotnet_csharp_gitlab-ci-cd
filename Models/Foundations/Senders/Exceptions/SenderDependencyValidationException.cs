using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class SenderDependencyValidationException : Xeption
    {
        public SenderDependencyValidationException(Xeption innerException)
            : base(message: "Sender dependency validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
