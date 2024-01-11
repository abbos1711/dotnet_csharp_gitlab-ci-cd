using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class FailedSenderServiceException : Xeption
    {
        public FailedSenderServiceException(Exception innerException)
            : base(message: "Failed sender service error occurred, please contact support", innerException)
        { }
    }
}
