using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Emails.Exceptions
{
    public class FailedEmailServerException : Xeption
    {
        public FailedEmailServerException(Exception innerException)
            : base(message: "Failed email server error occurred, contact support.", innerException)
        { }
    }
}
