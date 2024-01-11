using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Senders;

namespace dosLogistic.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Sender> InsertSenderAsync(Sender sender);
        IQueryable<Sender> SelectAllSenders();
        ValueTask<Sender> SelectSenderByIdAsync(Guid id);
        ValueTask<Sender> UpdateSenderAsync(Sender sender);
        ValueTask<Sender> DeleteSenderAsync(Sender sender);
    }
}
