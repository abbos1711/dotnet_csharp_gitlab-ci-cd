using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class AlreadyExistsMessageException : Xeption
    {
        public AlreadyExistsMessageException(Exception innerException)
            : base(message: "Message already exists", innerException)
        { }
    }
}
