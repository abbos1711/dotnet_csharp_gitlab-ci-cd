using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class NotFoundMessageException : Xeption
    {
        public NotFoundMessageException(Guid messageId) : base(message: $"Couldn't find message with id: {messageId}")
        { }
    }
}
