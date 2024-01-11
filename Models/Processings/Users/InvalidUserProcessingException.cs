using Xeptions;

namespace dosLogistic.API.Models.Processings.Users
{
    public class InvalidUserProcessingException : Xeption
    {
        public InvalidUserProcessingException()
            : base(message: "Invalid email and password, Please correct the errors and try again.")
        { }
    }
}
