using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class InvalidMessageReferenceException : Xeption
    {
        public InvalidMessageReferenceException(Exception innerException) :
            base(message: "Invalid message reference error occurred!", innerException)
        { }
    }
}
