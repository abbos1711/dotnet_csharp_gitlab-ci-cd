using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class NullSenderException : Xeption
    {
        public NullSenderException() : base(message: "Sender is null.")
        { }
    }
}
