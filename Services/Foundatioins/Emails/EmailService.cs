using System.Threading.Tasks;
using dosLogistic.API.Brokers.Emails;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Models.Foundations.Emails;
using PostmarkDotNet;

namespace dosLogistic.API.Services.Foundatioins.Emails
{
    public partial class EmailService : IEmailService
    {
        private readonly IEmailBroker emailBroker;
        private readonly ILoggingBroker loggingBroker;

        public EmailService(
            IEmailBroker emailBroker,
            ILoggingBroker loggingBroker)
        {
            this.emailBroker = emailBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Email> SendEmailAsync(Email email) =>
        TryCatch(async () =>
        {
            ValidateEmailOnSend(email);
            PostmarkResponse postmarkResponse = await this.emailBroker.SendEmailAsync(email);

            return postmarkResponse.Status is PostmarkStatus.Success
                ? email
                : ConvertToMeaningfulError(postmarkResponse);
        });
    }
}
