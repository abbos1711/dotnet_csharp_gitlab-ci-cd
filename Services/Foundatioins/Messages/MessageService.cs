using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Brokers.DataTimes;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Brokers.Storages;
using dosLogistic.API.Models.Foundations.Messages;

namespace dosLogistic.API.Services.Foundatioins.Messages
{
    public partial class MessageService : IMessageService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;
        public MessageService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Message> AddMessageAsync(Message message) =>
        TryCatch(async () =>
        {
            ValidateMessageOnAdd(message);

            return await this.storageBroker.InsertMessageAsync(message);
        });

        public IQueryable<Message> RetrieveAllMessages() =>
        TryCatch(() => this.storageBroker.SelectAllMessages());

        public ValueTask<Message> RetrieveMessageByIdAsync(Guid messageId) =>
        TryCatch(async () =>
        {
            ValidateMessageId(messageId);

            Message maybeMessage =
                await this.storageBroker.SelectMessageByIdAsync(messageId);

            ValidateStorageMessage(maybeMessage, messageId);

            return maybeMessage;

        });

        public ValueTask<Message> RemoveMessageByIdAsync(Guid messageId) =>
        TryCatch(async () =>
        {
            ValidateMessageId(messageId);

            Message maybeMessage =
                await this.storageBroker.SelectMessageByIdAsync(messageId);

            ValidateStorageMessage(maybeMessage, messageId);

            return await this.storageBroker.DeleteMessageAsync(maybeMessage);
        });
    }
}
