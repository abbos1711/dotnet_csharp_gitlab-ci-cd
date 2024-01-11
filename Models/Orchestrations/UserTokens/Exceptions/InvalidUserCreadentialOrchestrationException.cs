using Xeptions;

namespace dosLogistic.API.Models.Orchestrations.UserTokens.Exceptions
{
    public class InvalidUserCredentialOrchestrationException : Xeption
    {
        public InvalidUserCredentialOrchestrationException()
            : base(message: "Credential missing. Fix the error and try again.")
        { }
    }
}
