﻿using System;
using dosLogistic.API.Models.Foundations.Emails;
using dosLogistic.API.Models.Foundations.Emails.Exceptions;

namespace dosLogistic.API.Services.Foundatioins.Emails
{
    public partial class EmailService
    {
        private void ValidateEmailOnSend(Email email)
        {
            ValidateEmailNotNull(email);

            Validate(
                (Rule: IsInvalid(email.SenderAddress), Parameter: nameof(Email.SenderAddress)),
                (Rule: IsInvalid(email.ReceiverAddress), Parameter: nameof(Email.ReceiverAddress)),
                (Rule: IsInvalid(email.Subject), Parameter: nameof(Email.Subject)),
                (Rule: IsInvalid(email.HtmlBody), Parameter: nameof(Email.HtmlBody)));
        }

        private static void ValidateEmailNotNull(Email email)
        {
            if (email is null)
            {
                throw new NullEmailException();
            }
        }

        private dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidEmailException = new InvalidEmailException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidEmailException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidEmailException.ThrowIfContainsErrors();
        }
    }
}
