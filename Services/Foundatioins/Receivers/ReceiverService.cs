using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Brokers.DataTimes;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Brokers.Storages;
using dosLogistic.API.Models.Foundations.Receivers;
using dosLogistic.API.Services.Processings.CurrentUserDetails;

namespace dosLogistic.API.Services.Foundatioins.Receivers
{
    public partial class ReceiverService : IReceiverService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public ReceiverService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Receiver> AddReceiverAsync(Receiver receiver) =>
        TryCatch(async () =>
        {
            receiver.UserId = CurrentUserDetaile.UserId();

            ValidateReceiverOnAdd(receiver);

            return await this.storageBroker.InsertReceiverAsync(receiver);
        });

        public IQueryable<Receiver> RetrieveReceiversByUserId() =>
        TryCatch(() => this.storageBroker.SelectAllReceivers()
            .Where(x => x.UserId == CurrentUserDetaile.UserId()));

        public ValueTask<Receiver> RetrieveReceiverByIdAsync(Guid receiverId) =>
        TryCatch(async () =>
        {
            ValidateReceiverId(receiverId);

            Receiver maybeReceiver =
                await this.storageBroker.SelectReceiverByIdAsync(receiverId);

            ValidateStorageReceiver(maybeReceiver, receiverId);

            return maybeReceiver;
        });

        public ValueTask<Receiver> ModifyReceiverAsync(Receiver receiver) =>
        TryCatch(async () =>
        {
            receiver.UserId = CurrentUserDetaile.UserId();

            ValidateReceiverOnModify(receiver);
            var maybeReceiver = await this.storageBroker.SelectReceiverByIdAsync(receiver.Id);

            ValidateStorageReceiver(maybeReceiver, receiver.Id);
            ValidateAginstStorageReceiverOnModify(inputReceiver: receiver, storageReceiver: maybeReceiver);

            return await this.storageBroker.UpdateReceiverAsync(receiver);
        });

        public ValueTask<Receiver> RemoveReceiverByIdAsync(Guid receiverId) =>
        TryCatch(async () =>
        {
            ValidateReceiverId(receiverId);

            Receiver maybeReceiver = await this.storageBroker
                .SelectReceiverByIdAsync(receiverId);

            ValidateStorageReceiver(maybeReceiver, receiverId);

            return await this.storageBroker.DeleteReceiverAsync(maybeReceiver);
        });
    }
}