using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Emails;
using PostmarkDotNet;

namespace dosLogistic.API.Brokers.Emails
{
    public interface IEmailBroker
    {
        Task<PostmarkResponse> SendEmailAsync(Email email);
    }
}
