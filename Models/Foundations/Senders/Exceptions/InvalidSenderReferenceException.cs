using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class InvalidSenderReferenceException : Xeption
    {
        public InvalidSenderReferenceException(Exception innerException)
            : base(message: "Invalid sender reference error occurred.", innerException)
        { }
    }
}
