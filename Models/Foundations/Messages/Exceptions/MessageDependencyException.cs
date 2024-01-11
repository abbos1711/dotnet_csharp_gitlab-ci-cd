using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class MessageDependencyException : Xeption
    {
        public MessageDependencyException(Exception innerException)
            : base(message: "Message dependency error occurred, contact support!", innerException)
        { }
    }
}
