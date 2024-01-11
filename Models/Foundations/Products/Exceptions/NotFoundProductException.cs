using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Products.Exceptions
{
    public class NotFoundProductException : Xeption
    {
        public NotFoundProductException(Guid ticketId)
            : base(message: $"Couldn't find Product with id: {ticketId}.")
        { }
    }
}
