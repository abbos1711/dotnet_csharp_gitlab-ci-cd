using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class MessageServiceException : Xeption
    {
        public MessageServiceException(Exception innerException)
            : base(message: "Message service error occurred, contact support!", innerException)
        {

        }
    }
}
