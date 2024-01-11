using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Emails.Exceptions
{
    public class FailedEmailServiceException : Xeption
    {
        public FailedEmailServiceException(Exception innerException)
            : base(message: "Failed email service error occurred, contact support.", innerException)
        { }
    }
}
