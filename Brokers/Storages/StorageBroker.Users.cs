using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Users;
using Microsoft.EntityFrameworkCore;

namespace dosLogistic.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);

        public IQueryable<User> SelectAllUsers() =>
            SelectAll<User>();

        public async ValueTask<User> SelectUserByIdAsync(Guid id) =>
            await SelectAsync<User>(id);

        public async ValueTask<User> UpdateUserAsync(User user) =>
            await UpdateAsync(user);

        public async ValueTask<User> DeleteUserAsync(User user) =>
            await DeleteAsync(user);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUserEmail(modelBuilder.Entity<User>());

            var time = DateTime.Now;
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Super Admin",
                    LastName = "0",
                    BirthDate = DateTime.Now,
                    CreatedDate = time,
                    UpdatedDate = time,
                    Email = "SuperAdmin@email.com",
                    Gender = Gender.Man,
                    PassportJshshir = "0",
                    PassportSeriesAndNumber = "0",
                    Password = "Admin123!@#",
                    PhoneNumber = "0",
                    Role = UserRole.SuperAdmin,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Manager Admin",
                    LastName = "0",
                    BirthDate = DateTime.Now,
                    CreatedDate = time,
                    UpdatedDate = time,
                    Email = "ManagerAdmin@email.com",
                    Gender = Gender.Man,
                    PassportJshshir = "0",
                    PassportSeriesAndNumber = "0",
                    Password = "Admin123!@#",
                    PhoneNumber = "0",
                    Role = UserRole.Admin,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Poland Admin",
                    LastName = "0",
                    BirthDate = DateTime.Now,
                    CreatedDate = time,
                    UpdatedDate = time,
                    Email = "poland.admin@email.com",
                    Gender = Gender.Man,
                    PassportJshshir = "0",
                    PassportSeriesAndNumber = "0",
                    Password = "Admin123!@#",
                    PhoneNumber = "0",
                    Role = UserRole.PolandAdmin,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "German Admin",
                    LastName = "0",
                    BirthDate = DateTime.Now,
                    CreatedDate = time,
                    UpdatedDate = time,
                    Email = "german.admin@email.com",
                    Gender = Gender.Man,
                    PassportJshshir = "0",
                    PassportSeriesAndNumber = "0",
                    Password = "Admin123!@#",
                    PhoneNumber = "0",
                    Role = UserRole.GermanAdmin,
                }
            );
        }
    }
}
