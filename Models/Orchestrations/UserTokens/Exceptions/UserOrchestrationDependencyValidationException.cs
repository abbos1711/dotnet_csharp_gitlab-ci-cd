using Xeptions;

namespace dosLogistic.API.Models.Orchestrations.UserTokens.Exceptions
{
    public class UserOrchestrationDependencyValidationException : Xeption
    {
        public UserOrchestrationDependencyValidationException(Xeption innerException)
            : base(message: "User dependecny validation error occurred, fix the errors and try again.", innerException)
        { }
    }
}
