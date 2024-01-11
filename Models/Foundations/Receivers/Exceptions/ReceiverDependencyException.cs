using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class ReceiverDependencyException : Xeption
    {
        public ReceiverDependencyException(Xeption innerException)
            : base(message: "Receiver dependency error occurred, contact support.", innerException)
        { }
    }
}
