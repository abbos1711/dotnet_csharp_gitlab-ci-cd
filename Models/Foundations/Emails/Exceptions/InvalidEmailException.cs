using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Emails.Exceptions
{
    public class InvalidEmailException : Xeption
    {
        public InvalidEmailException()
           : base(message: "Email is invalid.")
        { }

        public InvalidEmailException(Exception innerException)
            : base(message: "Email is invalid. See inner exception for more details.", innerException)
        { }
    }
}
