using dosLogistic.API.Models.Foundations.Users;

namespace dosLogistic.API.Services.Processings.Users
{
    public interface IUserProcessingService
    {
        User RetrieveUserByCredentails(string email, string password);
    }
}
