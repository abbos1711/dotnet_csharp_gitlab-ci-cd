using System;
using dosLogistic.API.Models.Foundations.Parcels;
using dosLogistic.API.Models.Foundations.Parcels.Exceptions;
using dosLogistic.API.Models.Foundations.Users.Exceptions;

namespace dosLogistic.API.Services.Foundatioins.Parcels
{
    public partial class ParcelService
    {
        private void ValidateParcelOnAdd(ParcelUserCreation parcel)
        {
            ValidateParcelNotNull(parcel);
            Validate(
                (Rule: IsInvalid(parcel.Id), Parameter: nameof(parcel.Id)),
                (Rule: IsInvalid(parcel.ParcelName), Parameter: nameof(parcel.ParcelName)),
                (Rule: IsInvalid(parcel.Amount), Parameter: nameof(parcel.Amount)));
        }

        private void ValidateParcelId(Guid parcelId) =>
            Validate((Rule: IsInvalid(parcelId), Parameter: nameof(Parcel.Id)));

        private void ValidateAginstStorageParcelOnModify(Parcel inputParcel, Parcel storageParcel)
        {
            ValidateStorageParcel(storageParcel, inputParcel.Id);

            Validate(
                (Rule: IsSame(
                    firstDate: inputParcel.UpdatedDate,
                    secondDate: storageParcel.UpdatedDate,
                    secondDateName: nameof(Parcel.UpdatedDate)),
                Parameter: nameof(Parcel.UpdatedDate)));
        }

        private static void ValidateStorageParcel(Parcel maybeParcel, Guid parcelId)
        {
            if (maybeParcel is null)
            {
                throw new NotFoundUserException(parcelId);
            }
        }

        private void ValidateParcelOnModify(ParcelUserCreation parcel)
        {
            ValidateParcelNotNull(parcel);

            Validate(
                (Rule: IsInvalid(parcel.Id), Parameter: nameof(parcel.Id)),
                (Rule: IsInvalid(parcel.ParcelName), Parameter: nameof(parcel.ParcelName)),
                (Rule: IsInvalid(parcel.Amount), Parameter: nameof(parcel.Amount)));
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

        private static dynamic IsInvalid(int number) => new
        {
            Condition = number == default,
            Message = "Number is required"
        };

        private static dynamic IsInvalid(decimal number) => new
        {
            Condition = number == default,
            Message = "Number is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Value is required"
        };

        private dynamic IsSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate == secondDate,
                Message = $"Date is the same as {secondDateName}"
            };

        private static void ValidateParcelNotNull(Parcel Parcel)
        {
            if (Parcel is null)
            {
                throw new NullParcelException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidParcelException = new InvalidParcelException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidParcelException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidParcelException.ThrowIfContainsErrors();
        }
    }
}
