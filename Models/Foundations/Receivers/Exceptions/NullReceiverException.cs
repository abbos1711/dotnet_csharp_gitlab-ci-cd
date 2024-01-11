using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class NullReceiverException : Xeption
    {
        public NullReceiverException() : base(message: "Receiver is null.")
        { }
    }
}
