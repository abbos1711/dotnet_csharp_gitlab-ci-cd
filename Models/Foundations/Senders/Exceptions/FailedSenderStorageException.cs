using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class FailedSenderStorageException : Xeption
    {
        public FailedSenderStorageException(Exception innerException)
            : base(message: "Failed sender storage error occurred, contact support.", innerException)
        { }
    }
}
