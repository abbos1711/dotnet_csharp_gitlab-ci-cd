using dosLogistic.API.Models.Foundations.Users;

namespace dosLogistic.API.Services.Foundatioins.Securities
{
    public interface ISecurityService
    {
        string CreateToken(User user);
    }
}
