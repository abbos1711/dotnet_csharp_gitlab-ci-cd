using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class LockedSenderException : Xeption
    {
        public LockedSenderException(Exception innerException)
            : base(message: "Sender is locked, please try again.", innerException)
        { }
    }
}
