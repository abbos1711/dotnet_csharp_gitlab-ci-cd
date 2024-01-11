using Xeptions;

namespace dosLogistic.API.Models.Foundations.Users.Exceptions
{
    public class InvalidUserException : Xeption
    {
        public InvalidUserException()
          : base(message: "User is invalid.")
        { }
    }
}