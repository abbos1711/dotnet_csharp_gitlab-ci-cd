using System;
using dosLogistic.API.Models.Foundations.Senders;
using dosLogistic.API.Models.Foundations.Senders.Exceptions;

namespace dosLogistic.API.Services.Foundatioins.Senders
{
    public partial class SenderService
    {
        private void ValidateSenderOnAdd(Sender sender)
        {
            ValidateSenderNotNull(sender);

            Validate(
                (Rule: IsInvalid(sender.Id), Parameter: nameof(Sender.Id)),
                (Rule: IsInvalid(sender.FirstName), Parameter: nameof(Sender.FirstName)),
                (Rule: IsInvalid(sender.LastName), Parameter: nameof(Sender.LastName)),
                (Rule: IsInvalid(sender.PassportNumber), Parameter: nameof(Sender.PassportNumber)),
                (Rule: IsInvalid(sender.PassportJshshir), Parameter: nameof(Sender.PassportJshshir)),
                (Rule: IsInvalid(sender.City), Parameter: nameof(Sender.City)),
                (Rule: IsInvalid(sender.Region), Parameter: nameof(Sender.Region)),
                (Rule: IsInvalid(sender.Address), Parameter: nameof(Sender.Address)),
                (Rule: IsInvalid(sender.Phone), Parameter: nameof(Sender.Phone)),
                (Rule: IsInvalid(sender.CreatedDate), Parameter: nameof(Sender.CreatedDate)),
                (Rule: IsInvalid(sender.UpdatedDate), Parameter: nameof(Sender.UpdatedDate)),
                (Rule: IsNotRecent(sender.CreatedDate), Parameter: nameof(Sender.CreatedDate)),

                (Rule: IsNotSame(
                    firstDate: sender.CreatedDate,
                    secondDate: sender.UpdatedDate,
                    secondDateName: nameof(Sender.UpdatedDate)),

                Parameter: nameof(Sender.CreatedDate)));
        }

        private void ValidateAginstStorageSenderOnModify(Sender inputSender, Sender storageSender)
        {
            ValidateStorageSender(storageSender, inputSender.Id);

            Validate(
                (Rule: IsSame(
                    firstDate: inputSender.UpdatedDate,
                    secondDate: storageSender.UpdatedDate,
                    secondDateName: nameof(Sender.UpdatedDate)),
                Parameter: nameof(Sender.UpdatedDate)));
        }

        private void ValidateSenderOnModify(Sender sender)
        {
            ValidateSenderNotNull(sender);

            Validate(
                (Rule: IsInvalid(sender.Id), Parameter: nameof(Sender.Id)),
                (Rule: IsInvalid(sender.FirstName), Parameter: nameof(Sender.FirstName)),
                (Rule: IsInvalid(sender.LastName), Parameter: nameof(Sender.LastName)),
                (Rule: IsInvalid(sender.PassportNumber), Parameter: nameof(Sender.PassportNumber)),
                (Rule: IsInvalid(sender.PassportJshshir), Parameter: nameof(Sender.PassportJshshir)),
                (Rule: IsInvalid(sender.City), Parameter: nameof(Sender.City)),
                (Rule: IsInvalid(sender.Region), Parameter: nameof(Sender.Region)),
                (Rule: IsInvalid(sender.Address), Parameter: nameof(Sender.Address)),
                (Rule: IsInvalid(sender.Phone), Parameter: nameof(Sender.Phone)),
                (Rule: IsNotRecent(sender.UpdatedDate), Parameter: nameof(Sender.UpdatedDate)),

                (Rule: IsSame(
                        firstDate: sender.UpdatedDate,
                        secondDate: sender.CreatedDate,
                        secondDateName: nameof(sender.CreatedDate)),

                     Parameter: nameof(sender.UpdatedDate)));
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

        private void ValidateSenderId(Guid senderId) =>
            Validate((Rule: IsInvalid(senderId), Parameter: nameof(Sender.Id)));

        private void ValidateStorageSender(Sender maybeSender, Guid senderId)
        {
            if (maybeSender is null)
            {
                throw new NotFoundSenderException(senderId);
            }
        }

        private static void ValidateSenderNotNull(Sender sender)
        {
            if (sender is null)
            {
                throw new NullSenderException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidSenderException = new InvalidSenderException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidSenderException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidSenderException.ThrowIfContainsErrors();
        }
    }
}
