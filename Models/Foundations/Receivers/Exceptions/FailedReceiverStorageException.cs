using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class FailedReceiverStorageException : Xeption
    {
        public FailedReceiverStorageException(Exception innerException)
            : base(message: "Failed receiver storage error occurred, contact support.", innerException)
        { }
    }
}
