using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Receivers;

namespace dosLogistic.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Receiver> InsertReceiverAsync(Receiver receiver);
        IQueryable<Receiver> SelectAllReceivers();
        ValueTask<Receiver> SelectReceiverByIdAsync(Guid id);
        ValueTask<Receiver> UpdateReceiverAsync(Receiver receiver);
        ValueTask<Receiver> DeleteReceiverAsync(Receiver receiver);
    }
}
