using System;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Emails;
using dosLogistic.API.Models.Foundations.Emails.Exceptions;
using PostmarkDotNet;
using Xeptions;

namespace dosLogistic.API.Services.Foundatioins.Emails
{
    public partial class EmailService
    {
        private delegate ValueTask<Email> ReturningEmailFunction();

        private async ValueTask<Email> TryCatch(ReturningEmailFunction returningEmailFunction)
        {
            try
            {
                return await returningEmailFunction();
            }
            catch (NullEmailException nullEmailException)
            {
                throw CreateAndLogValidationException(nullEmailException);
            }
            catch (FailedEmailServerException failedEmailServerException)
            {
                throw CreateAndLogCriticalDependencyException(failedEmailServerException);
            }
            catch (InvalidEmailException invalidEmailException)
                when (invalidEmailException.InnerException is not null)
            {
                throw CreateAndLogDependencyValidationException(invalidEmailException);
            }
            catch (InvalidEmailException invalidEmailException)
            {
                throw CreateAndLogValidationException(invalidEmailException);
            }
            catch (Exception exception)
            {
                var failedEmailServiceException = new FailedEmailServiceException(exception);

                throw CreateAndLogServiceException(failedEmailServiceException);
            }
        }

        private EmailValidationException CreateAndLogValidationException(Xeption exception)
        {
            var emailValidationException = new EmailValidationException(exception);
            this.loggingBroker.LogError(emailValidationException);

            return emailValidationException;
        }

        private EmailDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var emailDependencyException = new EmailDependencyException(exception);
            this.loggingBroker.LogCritical(emailDependencyException);

            return emailDependencyException;
        }

        private EmailDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var emailDependencyValidationException = new EmailDependencyValidationException(exception);
            this.loggingBroker.LogError(emailDependencyValidationException);

            return emailDependencyValidationException;
        }

        private EmailServiceException CreateAndLogServiceException(Xeption exception)
        {
            var emailServiceException = new EmailServiceException(exception);
            this.loggingBroker.LogError(emailServiceException);

            return emailServiceException;
        }

        private Email ConvertToMeaningfulError(PostmarkResponse postmarkResponse)
        {
            var innerException = new Exception(postmarkResponse.Message);

            return postmarkResponse.Status switch
            {
                PostmarkStatus.ServerError => throw new FailedEmailServerException(innerException),
                PostmarkStatus.UserError => throw new InvalidEmailException(innerException),
                _ => throw new FailedEmailServerException(innerException)
            };
        }
    }
}
