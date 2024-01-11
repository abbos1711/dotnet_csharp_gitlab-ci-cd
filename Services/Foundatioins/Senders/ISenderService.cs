using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Senders;

namespace dosLogistic.API.Services.Foundatioins.Senders
{
    public interface ISenderService
    {
        ValueTask<Sender> AddSenderAsync(Sender sender);
        IQueryable<Sender> RetrieveSendersByUserId();
        ValueTask<Sender> RetrieveSenderByIdAsync(Guid senderId);
        ValueTask<Sender> ModifySenderAsync(Sender sender);
        ValueTask<Sender> RemoveSenderByIdAsync(Guid senderId);
    }
}
