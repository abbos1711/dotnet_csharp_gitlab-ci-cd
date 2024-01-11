using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class AlreadyExistsReceiverException : Xeption
    {
        public AlreadyExistsReceiverException(Exception innerException)
            : base(message: "Receiver already exists.", innerException)
        { }
    }
}
