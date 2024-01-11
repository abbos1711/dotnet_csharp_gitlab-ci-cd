using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Emails;

namespace dosLogistic.API.Services.Foundatioins.Emails
{
    public interface IEmailService
    {
        ValueTask<Email> SendEmailAsync(Email email);
    }
}
