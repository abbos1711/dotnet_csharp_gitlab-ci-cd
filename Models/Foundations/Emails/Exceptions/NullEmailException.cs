using Xeptions;

namespace dosLogistic.API.Models.Foundations.Emails.Exceptions
{
    public class NullEmailException : Xeption
    {
        public NullEmailException()
            : base(message: "Email is null.")
        { }
    }
}
