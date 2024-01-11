using System;
using dosLogistic.API.Models.Foundations.Messages;
using dosLogistic.API.Models.Foundations.Messages.Exceptions;

namespace dosLogistic.API.Services.Foundatioins.Messages
{
    public partial class MessageService
    {
        private void ValidateMessageOnAdd(Message message)
        {
            ValidateMessageNotNull(message);
            Validate(
                (Rule: IsInvalid(message.Id), Parameter: nameof(Message.Id)),
                (Rule: IsInvalid(message.FullName), Parameter: nameof(Message.FullName)),
                (Rule: IsInvalid(message.Email), Parameter: nameof(Message.Email)),
                (Rule: IsInvalid(message.Phone), Parameter: nameof(Message.Phone)),
                (Rule: IsInvalid(message.City), Parameter: nameof(Message.City)),
                (Rule: IsInvalid(message.Subject), Parameter: nameof(Message.Subject)),
                (Rule: IsInvalid(message.Text), Parameter: nameof(Message.Text)),
                (Rule: IsInvalid(message.Status), Parameter: nameof(Message.Status)),
            (Rule: IsSame(
                        firstDate: message.UpdatedDate,
                        secondDate: message.CreatedDate,
                        secondDateName: nameof(message.CreatedDate)),

                     Parameter: nameof(message.UpdatedDate)));
        }

        private dynamic IsSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate == secondDate,
                Message = $"Date is the same as {secondDateName}"
            };

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string anyData) => new
        {
            Condition = anyData == default,
            Message = $"{anyData} is required"
        };

        private static dynamic IsInvalid<T>(T value) => new
        {
            Condition = IsEnumInvalid(value),
            Message = "Value is not recognized"
        };

        private static bool IsEnumInvalid<T>(T value)
        {
            bool isDefined = Enum.IsDefined(typeof(T), value);

            return isDefined is false;
        }

        private void ValidateStorageMessage(Message maybeMessage, Guid messageId)
        {
            if (maybeMessage is null)
            {
                throw new NotFoundMessageException(messageId);
            }
        }

        private void ValidateMessageId(Guid messageId) =>
            Validate((Rule: IsInvalid(messageId), Parameter: nameof(Message.Id)));

        private static void ValidateMessageNotNull(Message message)
        {
            if (message is null)
            {
                throw new NullMessageException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidScoreException = new InvalidMessageException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidScoreException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidScoreException.ThrowIfContainsErrors();
        }
    }
}
