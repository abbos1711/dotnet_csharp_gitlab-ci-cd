using dosLogistic.API.Models.Foundations.Users;
using dosLogistic.API.Models.Processings.Users;

namespace dosLogistic.API.Services.Processings.Users
{
    public partial class UserProcessingService
    {
        private static void ValidateEmailAndPassword(string email, string password)
        {
            Validate(
                (Rule: IsInvalid(email), Parameter: nameof(User.Email)),
                (Rule: IsInvalid(password), Parameter: nameof(User.Password)));
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserProcessingException =
                new InvalidUserProcessingException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidUserProcessingException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidUserProcessingException.ThrowIfContainsErrors();
        }
    }
}
