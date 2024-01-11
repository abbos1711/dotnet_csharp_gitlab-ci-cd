using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class NotFoundSenderException : Xeption
    {
        public NotFoundSenderException(Guid ticketId)
            : base(message: $"Couldn't find sender with id: {ticketId}.")
        { }
    }
}
