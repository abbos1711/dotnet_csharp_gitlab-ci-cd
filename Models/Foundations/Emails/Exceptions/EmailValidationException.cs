using Xeptions;

namespace dosLogistic.API.Models.Foundations.Emails.Exceptions
{
    public class EmailValidationException : Xeption
    {
        public EmailValidationException(Xeption innerException)
            : base(message: "Email validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
