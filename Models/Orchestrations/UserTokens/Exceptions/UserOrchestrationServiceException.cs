using Xeptions;

namespace dosLogistic.API.Models.Orchestrations.UserTokens.Exceptions
{
    public class UserOrchestrationServiceException : Xeption
    {
        public UserOrchestrationServiceException(Xeption innerException)
            : base(message: "User token service error occurred, contact support.", innerException)
        { }
    }
}
