using System;
using dosLogistic.API.Models.Foundations.Products;
using dosLogistic.API.Models.Foundations.Products.Exceptions;
using Microsoft.AspNetCore.Http;

namespace dosLogistic.API.Services.Foundatioins.Products
{
    public partial class ProductService
    {
        private void ValidateProductOnAdd(Product product)
        {
            ValidateProductNotNull(product);
            Validate(
                (Rule: IsInvalid(product.Id), Parameter: nameof(Product.Id)),
                (Rule: IsInvalid(product.TrackingId), Parameter: nameof(Product.TrackingId)),
                (Rule: IsInvalid(product.ShopName), Parameter: nameof(Product.ShopName)),
                (Rule: IsInvalid(product.TrackingId), Parameter: nameof(Product.TrackingId)),
                (Rule: IsInvalid(product.Amount), Parameter: nameof(Product.Amount)),
                (Rule: IsInvalid(product.ReceiverId), Parameter: nameof(Product.ReceiverId)),
                (Rule: IsInvalid(product.UserId), Parameter: nameof(Product.UserId)),
                (Rule: IsInvalid(product.CreatedDate), Parameter: nameof(Product.CreatedDate)),
                (Rule: IsInvalid(product.UpdatedDate), Parameter: nameof(Product.UpdatedDate)));
        }

        private void ValidateAginstStorageProductOnModify(Product inputProduct, Product storageProduct)
        {
            ValidateStorageProduct(storageProduct, inputProduct.Id);

            Validate(
                (Rule: IsSame(
                    firstDate: inputProduct.UpdatedDate,
                    secondDate: storageProduct.UpdatedDate,
                    secondDateName: nameof(Product.UpdatedDate)),
                Parameter: nameof(Product.UpdatedDate)));
        }

        private void ValidateProductOnModify(Product product)
        {
            ValidateProductNotNull(product);
            Validate(
                (Rule: IsInvalid(product.Id), Parameter: nameof(Product.Id)),
                (Rule: IsInvalid(product.CreatedDate), Parameter: nameof(Product.CreatedDate)),
                (Rule: IsInvalid(product.UpdatedDate), Parameter: nameof(Product.UpdatedDate)),
                (Rule: IsNotRecent(product.UpdatedDate), Parameter: nameof(product.UpdatedDate)),

                (Rule: IsSame(
                        firstDate: product.UpdatedDate,
                        secondDate: product.CreatedDate,
                        secondDateName: nameof(product.CreatedDate)),

                     Parameter: nameof(product.UpdatedDate)));
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

        private static dynamic IsInvalid(decimal number) => new
        {
            Conditional = number == default,
            Message = "Deciaml number is required!"
        };

        private static dynamic IsInvalid(int number) => new
        {
            Condition = number == default,
            Message = "Integar number is required!"
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

            return timeDifference.TotalSeconds is > 100 or < 0;
        }

        private void ValidateProductId(Guid productId) =>
            Validate((Rule: IsInvalid(productId), Parameter: nameof(Product.Id)));

        private void ValidateStorageProduct(Product maybeProduct, Guid productId)
        {
            if (maybeProduct is null)
            {
                throw new NotFoundProductException(productId);
            }
        }


        private static void ValidateProductNotNull(Product product)
        {
            if (product is null)
            {
                throw new NullProductException();
            }
        }

        private void ValidateFormFileNotNull(IFormFile imageFile)
        {
            if (imageFile is null)
            {
                throw new NullImageExeption();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidProductException = new InvalidProductException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidProductException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidProductException.ThrowIfContainsErrors();
        }
    }
}
