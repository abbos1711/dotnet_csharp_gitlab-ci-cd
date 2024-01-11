using System;
using dosLogistic.API.Models.Foundations.Receivers;
using dosLogistic.API.Models.Foundations.Receivers.Exceptions;

namespace dosLogistic.API.Services.Foundatioins.Receivers
{
    public partial class ReceiverService
    {
        private void ValidateReceiverOnAdd(Receiver receiver)
        {
            ValidateReceiverNotNull(receiver);

            Validate(
                (Rule: IsInvalid(receiver.Id), Parameter: nameof(Receiver.Id)),
                (Rule: IsInvalid(receiver.FirstName), Parameter: nameof(Receiver.FirstName)),
                (Rule: IsInvalid(receiver.LastName), Parameter: nameof(Receiver.LastName)),
                (Rule: IsInvalid(receiver.PassportNumber), Parameter: nameof(Receiver.PassportNumber)),
                (Rule: IsInvalid(receiver.PassportJshshir), Parameter: nameof(Receiver.PassportJshshir)),
                (Rule: IsInvalid(receiver.City), Parameter: nameof(Receiver.City)),
                (Rule: IsInvalid(receiver.Region), Parameter: nameof(Receiver.Region)),
                (Rule: IsInvalid(receiver.Address), Parameter: nameof(Receiver.Address)),
                (Rule: IsInvalid(receiver.Phone), Parameter: nameof(Receiver.Phone)),
                (Rule: IsInvalid(receiver.CreatedDate), Parameter: nameof(Receiver.CreatedDate)),
                (Rule: IsInvalid(receiver.UpdatedDate), Parameter: nameof(Receiver.UpdatedDate)),
                (Rule: IsNotRecent(receiver.CreatedDate), Parameter: nameof(Receiver.CreatedDate)),

                (Rule: IsNotSame(
                    firstDate: receiver.CreatedDate,
                    secondDate: receiver.UpdatedDate,
                    secondDateName: nameof(Receiver.UpdatedDate)),

                Parameter: nameof(Receiver.CreatedDate)));
        }

        private void ValidateAginstStorageReceiverOnModify(Receiver inputReceiver, Receiver storageReceiver)
        {
            ValidateStorageReceiver(storageReceiver, inputReceiver.Id);

            Validate(
                (Rule: IsSame(
                    firstDate: inputReceiver.UpdatedDate,
                    secondDate: storageReceiver.UpdatedDate,
                    secondDateName: nameof(Receiver.UpdatedDate)),
                Parameter: nameof(Receiver.UpdatedDate)));
        }

        private void ValidateReceiverOnModify(Receiver receiver)
        {
            ValidateReceiverNotNull(receiver);

            Validate(
                (Rule: IsInvalid(receiver.Id), Parameter: nameof(Receiver.Id)),
                (Rule: IsInvalid(receiver.FirstName), Parameter: nameof(Receiver.FirstName)),
                (Rule: IsInvalid(receiver.LastName), Parameter: nameof(Receiver.LastName)),
                (Rule: IsInvalid(receiver.PassportNumber), Parameter: nameof(Receiver.PassportNumber)),
                (Rule: IsInvalid(receiver.PassportJshshir), Parameter: nameof(Receiver.PassportJshshir)),
                (Rule: IsInvalid(receiver.City), Parameter: nameof(Receiver.City)),
                (Rule: IsInvalid(receiver.Region), Parameter: nameof(Receiver.Region)),
                (Rule: IsInvalid(receiver.Address), Parameter: nameof(Receiver.Address)),
                (Rule: IsInvalid(receiver.Phone), Parameter: nameof(Receiver.Phone)),
                (Rule: IsNotRecent(receiver.UpdatedDate), Parameter: nameof(Receiver.UpdatedDate)),

                (Rule: IsSame(
                        firstDate: receiver.UpdatedDate,
                        secondDate: receiver.CreatedDate,
                        secondDateName: nameof(receiver.CreatedDate)),

                     Parameter: nameof(receiver.UpdatedDate)));
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

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Value is required"
        };

        private static dynamic IsInvalid<T>(T value) => new
        {
            Condition = IsEnumInvalid(value),
            Message = "Value is not recognized"
        };

        private static dynamic IsNotSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate != secondDate,
                Message = $"Date is not the same as {secondDateName}"
            };

        private static bool IsEnumInvalid<T>(T value)
        {
            bool isDefined = Enum.IsDefined(typeof(T), value);

            return isDefined is false;
        }

        private dynamic IsNotRecent(DateTimeOffset date) => new
        {
            Condition = IsDateNotRecent(date),
            Message = "Date is not recent"
        };

        private bool IsDateNotRecent(DateTimeOffset date)
        {
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTime();
            TimeSpan timeDifference = currentDateTime.Subtract(date);

            return timeDifference.TotalSeconds is > 60 or < 0;
        }

        private void ValidateReceiverId(Guid receiverId) =>
            Validate((Rule: IsInvalid(receiverId), Parameter: nameof(Receiver.Id)));

        private void ValidateStorageReceiver(Receiver maybeReceiver, Guid receiverId)
        {
            if (maybeReceiver is null)
            {
                throw new NotFoundReceiverException(receiverId);
            }
        }

        private static void ValidateReceiverNotNull(Receiver receiver)
        {
            if (receiver is null)
            {
                throw new NullReceiverException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidReceiverException = new InvalidReceiverException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidReceiverException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidReceiverException.ThrowIfContainsErrors();
        }
    }
}
