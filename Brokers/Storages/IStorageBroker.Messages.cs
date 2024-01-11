using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Messages;

namespace dosLogistic.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Message> InsertMessageAsync(Message message);
        IQueryable<Message> SelectAllMessages();
        ValueTask<Message> SelectMessageByIdAsync(Guid id);
        ValueTask<Message> DeleteMessageAsync(Message message);
    }
}
