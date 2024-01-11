using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Senders.Exceptions
{
    public class AlreadyExistsSenderException : Xeption
    {
        public AlreadyExistsSenderException(Exception innerException)
            : base(message: "Sender already exists.", innerException)
        { }
    }
}
