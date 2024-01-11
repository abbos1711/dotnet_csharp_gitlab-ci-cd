using Xeptions;

namespace dosLogistic.API.Models.Orchestrations.UserTokens.Exceptions
{
    public class UserOrchestrationDependencyException : Xeption
    {
        public UserOrchestrationDependencyException(Xeption innerException)
            : base(message: "User dependency error occurred, contact support.", innerException)
        { }
    }
}
