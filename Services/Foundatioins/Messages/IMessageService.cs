using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Messages;

namespace dosLogistic.API.Services.Foundatioins.Messages
{
    public interface IMessageService
    {
        ValueTask<Message> AddMessageAsync(Message message);
        IQueryable<Message> RetrieveAllMessages();
        ValueTask<Message> RetrieveMessageByIdAsync(Guid messageId);
        ValueTask<Message> RemoveMessageByIdAsync(Guid messageId);
    }
}
