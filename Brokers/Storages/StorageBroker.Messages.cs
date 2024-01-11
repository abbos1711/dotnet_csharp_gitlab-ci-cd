using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Messages;
using Microsoft.EntityFrameworkCore;

namespace dosLogistic.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Message> Messages { get; set; }

        public async ValueTask<Message> InsertMessageAsync(Message message) =>
            await InsertAsync(message);

        public IQueryable<Message> SelectAllMessages() =>
            SelectAll<Message>();

        public async ValueTask<Message> SelectMessageByIdAsync(Guid id) =>
            await SelectAsync<Message>(id);

        public async ValueTask<Message> DeleteMessageAsync(Message message) =>
            await DeleteAsync(message);
    }
}
