using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Receivers;
using Microsoft.EntityFrameworkCore;

namespace dosLogistic.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Receiver> Receivers { get; set; }

        public async ValueTask<Receiver> InsertReceiverAsync(Receiver receiver) =>
            await InsertAsync(receiver);

        public IQueryable<Receiver> SelectAllReceivers() =>
            SelectAll<Receiver>();

        public async ValueTask<Receiver> SelectReceiverByIdAsync(Guid id) =>
            await SelectAsync<Receiver>(id);

        public async ValueTask<Receiver> UpdateReceiverAsync(Receiver receiver) =>
            await UpdateAsync(receiver);

        public async ValueTask<Receiver> DeleteReceiverAsync(Receiver receiver) =>
            await DeleteAsync(receiver);
    }
}
