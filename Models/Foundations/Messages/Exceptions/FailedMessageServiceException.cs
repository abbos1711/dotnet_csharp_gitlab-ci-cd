using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class FailedMessageServiceException : Xeption
    {
        public FailedMessageServiceException(Exception innerException)
            : base(message: "Failed message service error occurred, please contact support", innerException)
        { }
    }
}
