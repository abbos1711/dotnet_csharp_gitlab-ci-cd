using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Brokers.DataTimes;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Brokers.Storages;
using dosLogistic.API.Models.Foundations.Users;

namespace dosLogistic.API.Services.Foundatioins.Users
{
    public partial class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<User> AddUserAsync(User user) =>
        TryCatch(async () =>
        {
            ValidateUserOnAdd(user);

            return await this.storageBroker.InsertUserAsync(user);
        });

        public IQueryable<User> RetrieveAllUsers() =>
        TryCatch(() => this.storageBroker.SelectAllUsers());

        public ValueTask<User> RetrieveUserByIdAsync(Guid userId) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);

            User maybeUser =
                await this.storageBroker.SelectUserByIdAsync(userId);

            ValidateStorageUser(maybeUser, userId);

            return maybeUser;
        });

        public ValueTask<User> ModifyUserAsync(User user) =>
        TryCatch(async () =>
        {
            ValidateUserOnModify(user);
            var maybeUser = await this.storageBroker.SelectUserByIdAsync(user.Id);
            ValidateAginstStorageUserOnModify(inputUser: user, storageUser: maybeUser);

            return await this.storageBroker.UpdateUserAsync(user);
        });

        public ValueTask<User> RemoveUserByIdAsync(Guid userId) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);

            User maybeUser =
                await this.storageBroker.SelectUserByIdAsync(userId);

            ValidateStorageUser(maybeUser, userId);

            return await this.storageBroker.DeleteUserAsync(maybeUser);
        });
    }
}
