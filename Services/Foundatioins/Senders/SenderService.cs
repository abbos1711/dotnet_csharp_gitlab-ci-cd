using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Brokers.DataTimes;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Brokers.Storages;
using dosLogistic.API.Models.Foundations.Senders;
using dosLogistic.API.Services.Processings.CurrentUserDetails;

namespace dosLogistic.API.Services.Foundatioins.Senders
{
    public partial class SenderService : ISenderService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public SenderService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Sender> AddSenderAsync(Sender sender) =>
        TryCatch(async () =>
        {
            sender.UserId = CurrentUserDetaile.UserId();

            ValidateSenderOnAdd(sender);

            return await this.storageBroker.InsertSenderAsync(sender);
        });

        public IQueryable<Sender> RetrieveSendersByUserId() =>
        TryCatch(() => this.storageBroker.SelectAllSenders()
            .Where(x => x.UserId == CurrentUserDetaile.UserId()));

        public ValueTask<Sender> RetrieveSenderByIdAsync(Guid senderId) =>
        TryCatch(async () =>
        {
            ValidateSenderId(senderId);

            Sender maybeSender =
                await this.storageBroker.SelectSenderByIdAsync(senderId);

            ValidateStorageSender(maybeSender, senderId);

            return maybeSender;
        });

        public ValueTask<Sender> ModifySenderAsync(Sender sender) =>
        TryCatch(async () =>
        {
            sender.UserId = CurrentUserDetaile.UserId();

            ValidateSenderOnModify(sender);
            var maybeSender = await this.storageBroker.SelectSenderByIdAsync(sender.Id);

            ValidateStorageSender(maybeSender, sender.Id);
            ValidateAginstStorageSenderOnModify(inputSender: sender, storageSender: maybeSender);

            return await this.storageBroker.UpdateSenderAsync(sender);
        });

        public ValueTask<Sender> RemoveSenderByIdAsync(Guid senderId) =>
        TryCatch(async () =>
        {
            ValidateSenderId(senderId);

            Sender maybeSender = await this.storageBroker
                .SelectSenderByIdAsync(senderId);

            ValidateStorageSender(maybeSender, senderId);

            return await this.storageBroker.DeleteSenderAsync(maybeSender);
        });
    }
}
