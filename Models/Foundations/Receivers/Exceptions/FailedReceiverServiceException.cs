using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class FailedReceiverServiceException : Xeption
    {
        public FailedReceiverServiceException(Exception innerException)
            : base(message: "Failed receiver service error occurred, please contact support", innerException)
        { }
    }
}
