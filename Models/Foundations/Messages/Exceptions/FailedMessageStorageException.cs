using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class FailedMessageStorageException : Xeption
    {
        public FailedMessageStorageException(Exception innerException)
            : base(message: "Failed message storage error occurred, contact support.", innerException)
        { }
    }
}
