using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class ReceiverServiceException : Xeption
    {
        public ReceiverServiceException(Exception innerException)
            : base(message: "Receiver service error occurred, contact support.", innerException)
        { }
    }
}
