using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class InvalidSenderException : Xeption
    {
        public InvalidSenderException()
            : base(message: "Sender is invalid.")
        { }
    }
}
