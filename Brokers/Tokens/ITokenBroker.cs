using dosLogistic.API.Models.Foundations.Users;

namespace dosLogistic.API.Brokers.Tokens
{
    public interface ITokenBroker
    {
        string GenerateJWT(User user);
    }
}
