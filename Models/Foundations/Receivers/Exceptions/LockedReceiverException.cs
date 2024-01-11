using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class LockedReceiverException : Xeption
    {
        public LockedReceiverException(Exception innerException)
            : base(message: "Receiver is locked, please try again.", innerException)
        { }
    }
}
