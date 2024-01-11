using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Brokers.Tokens;
using dosLogistic.API.Models.Foundations.Users;

namespace dosLogistic.API.Services.Foundatioins.Securities
{
    public partial class SecurityService : ISecurityService
    {
        private readonly ITokenBroker tokenBroker;
        private readonly ILoggingBroker loggingBroker;

        public SecurityService(
            ITokenBroker tokenBroker,
            ILoggingBroker loggingBroker)
        {
            this.tokenBroker = tokenBroker;
            this.loggingBroker = loggingBroker;
        }

        public string CreateToken(User user) =>
        TryCatch(() =>
        {
            ValidateUser(user);

            return tokenBroker.GenerateJWT(user);
        });
    }
}
