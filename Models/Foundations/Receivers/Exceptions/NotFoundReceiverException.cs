using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class NotFoundReceiverException : Xeption
    {
        public NotFoundReceiverException(Guid ticketId)
            : base(message: $"Couldn't find receiver with id: {ticketId}.")
        { }
    }
}
