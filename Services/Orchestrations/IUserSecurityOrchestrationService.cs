using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Users;
using dosLogistic.API.Models.Orchestrations.UserTokens;

namespace dosLogistic.API.Services.Orchestrations
{
    public interface IUserSecurityOrchestrationService
    {
        ValueTask<User> CreateUserAccountAsync(User user);
        UserToken CreateUserToken(string email, string password);
    }
}
