using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Receivers;

namespace dosLogistic.API.Services.Foundatioins.Receivers
{
    public interface IReceiverService
    {
        ValueTask<Receiver> AddReceiverAsync(Receiver receiver);
        IQueryable<Receiver> RetrieveReceiversByUserId();
        ValueTask<Receiver> RetrieveReceiverByIdAsync(Guid receiverId);
        ValueTask<Receiver> ModifyReceiverAsync(Receiver receiver);
        ValueTask<Receiver> RemoveReceiverByIdAsync(Guid receiverId);
    }
}
