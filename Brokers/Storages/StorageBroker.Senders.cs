using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Senders;
using Microsoft.EntityFrameworkCore;

namespace dosLogistic.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Sender> Senders { get; set; }

        public async ValueTask<Sender> InsertSenderAsync(Sender sender) =>
            await InsertAsync(sender);

        public IQueryable<Sender> SelectAllSenders() =>
            SelectAll<Sender>();

        public async ValueTask<Sender> SelectSenderByIdAsync(Guid id) =>
            await SelectAsync<Sender>(id);

        public async ValueTask<Sender> UpdateSenderAsync(Sender sender) =>
            await UpdateAsync(sender);

        public async ValueTask<Sender> DeleteSenderAsync(Sender sender) =>
            await DeleteAsync(sender);
    }
}
