using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class SenderDependencyException : Xeption
    {
        public SenderDependencyException(Xeption innerException)
            : base(message: "Sender dependency error occurred, contact support.", innerException)
        { }
    }
}
