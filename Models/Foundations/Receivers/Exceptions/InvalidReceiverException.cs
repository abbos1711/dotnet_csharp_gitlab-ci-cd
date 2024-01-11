using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class InvalidReceiverException : Xeption
    {
        public InvalidReceiverException()
            : base(message: "Receiver is invalid.")
        { }
    }
}
