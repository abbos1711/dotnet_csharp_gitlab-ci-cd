using System;
using Xeptions;

namespace dosLogistic.API.Models.Orchestrations.UserTokens.Exceptions
{
    public class FailedUserOrchestrationException : Xeption
    {
        public FailedUserOrchestrationException(Exception innerException)
            : base(message: "Failed user token service error occurred, contact support.", innerException)
        { }
    }
}
