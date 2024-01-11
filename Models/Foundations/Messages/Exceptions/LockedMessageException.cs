using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Messages.Exceptions
{
    public class LockedMessageException : Xeption
    {
        public LockedMessageException(Exception innerException)
            : base(message: "Message is locked, please try again!", innerException)
        { }
    }
}
