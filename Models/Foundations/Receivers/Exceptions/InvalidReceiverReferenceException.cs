using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class InvalidReceiverReferenceException : Xeption
    {
        public InvalidReceiverReferenceException(Exception innerException)
            : base(message: "Invalid receiver reference error occurred.", innerException)
        { }
    }
}
