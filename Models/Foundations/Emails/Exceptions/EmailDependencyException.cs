using Xeptions;

namespace dosLogistic.API.Models.Foundations.Emails.Exceptions
{
    public class EmailDependencyException : Xeption
    {
        public EmailDependencyException(Xeption innerException)
            : base(message: "Email dependency error occurred, contact support.", innerException)
        { }
    }
}
