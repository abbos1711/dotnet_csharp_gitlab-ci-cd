using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class SenderServiceException : Xeption
    {
        public SenderServiceException(Exception innerException)
            : base(message: "Sender service error occurred, contact support.", innerException)
        { }
    }
}
