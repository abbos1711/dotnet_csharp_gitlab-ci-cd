using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Models.Foundations.Emails;
using dosLogistic.API.Models.Foundations.Users;
using dosLogistic.API.Models.Orchestrations.UserTokens;
using dosLogistic.API.Services.Foundatioins.Emails;
using dosLogistic.API.Services.Foundatioins.Securities;
using dosLogistic.API.Services.Foundatioins.Users;

namespace dosLogistic.API.Services.Orchestrations
{
    public partial class UserSecurityOrchestrationService : IUserSecurityOrchestrationService
    {
        private readonly IUserService userService;
        private readonly ISecurityService securityService;
        private readonly IEmailService emailService;
        private readonly ILoggingBroker loggingBroker;

        public UserSecurityOrchestrationService(
            IUserService userService,
            ISecurityService securityService,
            IEmailService emailService,
            ILoggingBroker loggingBroker)
        {
            this.userService = userService;
            this.securityService = securityService;
            this.emailService = emailService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<User> CreateUserAccountAsync(User user) =>
        TryCatch(async () =>
        {
            User persistedUser = await this.userService.AddUserAsync(user);
            Email email = CreateUserEmail(persistedUser);
            await this.emailService.SendEmailAsync(email);

            return persistedUser;
        });

        public UserToken CreateUserToken(string email, string password) =>
        TryCatch(() =>
        {
            ValidateEmailAndPassword(email, password);
            User maybeUser = RetrieveUserByEmailAndPassword(email, password);
            ValidateUserExists(maybeUser);
            string token = this.securityService.CreateToken(maybeUser);

            return new UserToken
            {
                UserId = maybeUser.Id,
                Token = token
            };
        });

        private User RetrieveUserByEmailAndPassword(string email, string password)
        {
            IQueryable<User> allUser = this.userService.RetrieveAllUsers();

            return allUser.FirstOrDefault(retrievedUser => retrievedUser.Email.Equals(email)
                    && retrievedUser.Password.Equals(password));
        }

        private Email CreateUserEmail(User user)
        {
            string subject = "Confirm your email";
            string htmlBody = @$"
<!DOCTYPE html>
<html>
  <body>
    <h1>Hey {user.FirstName}</h1>
    <p>Thank you for registering for our schooling system. Please confirm your email address by clicking the button below.</p>
    <a href=""https://www.example.com/confirm-email"">
      <button>Confirm Email</button>
    </a>
  </body>
</html>
";

            return new Email
            {
                Id = Guid.NewGuid(),
                Subject = subject,
                HtmlBody = htmlBody,
                SenderAddress = "no-reply@dosLogistic.uz",
                ReceiverAddress = user.Email,
                TrackOpens = true
            };
        }
    }
}
