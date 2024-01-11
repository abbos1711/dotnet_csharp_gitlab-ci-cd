using Xeptions;

namespace dosLogistic.API.Models.Foundations.Emails.Exceptions
{
    public class EmailDependencyValidationException : Xeption
    {
        public EmailDependencyValidationException(Xeption innerException)
            : base(message: "Email dependency validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
