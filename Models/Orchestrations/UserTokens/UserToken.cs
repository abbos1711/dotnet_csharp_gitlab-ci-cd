using System;

namespace dosLogistic.API.Models.Orchestrations.UserTokens
{
    public class UserToken
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
