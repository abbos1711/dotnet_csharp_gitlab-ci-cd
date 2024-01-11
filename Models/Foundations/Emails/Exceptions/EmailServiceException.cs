using Xeptions;

namespace dosLogistic.API.Models.Foundations.Emails.Exceptions
{
    public class EmailServiceException : Xeption
    {
        public EmailServiceException(Xeption innerException)
            : base(message: "Email service error occurred, contact support.", innerException)
        { }
    }
}
