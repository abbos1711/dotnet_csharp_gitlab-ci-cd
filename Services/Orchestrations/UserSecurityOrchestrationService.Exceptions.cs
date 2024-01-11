﻿using System;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Emails.Exceptions;
using dosLogistic.API.Models.Foundations.Users;
using dosLogistic.API.Models.Foundations.Users.Exceptions;
using dosLogistic.API.Models.Orchestrations.UserTokens;
using dosLogistic.API.Models.Orchestrations.UserTokens.Exceptions;
using Xeptions;

namespace dosLogistic.API.Services.Orchestrations
{
    public partial class UserSecurityOrchestrationService
    {
        private delegate ValueTask<User> ReturningUserFunction();
        private delegate UserToken ReturningUserTokenFunction();

        private UserToken TryCatch(ReturningUserTokenFunction returningUserTokenFunction)
        {
            try
            {
                return returningUserTokenFunction();
            }
            catch (InvalidUserCredentialOrchestrationException invalidUserCreadentialOrchestrationException)
            {
                throw CreateAndLogValidationException(invalidUserCreadentialOrchestrationException);
            }
            catch (NotFoundUserException notFoundUserException)
            {
                throw CreateAndLogValidationException(notFoundUserException);
            }
            catch (UserDependencyException userDependencyException)
            {
                throw CreateAndLogDependencyException(userDependencyException);
            }
            catch (UserServiceException userServiceException)
            {
                throw CreateAndLogDependencyException(userServiceException);
            }
            catch (Exception exception)
            {
                var failedUserOrchestrationException =
                    new FailedUserOrchestrationException(exception);

                throw CreateAndLogServiceException(failedUserOrchestrationException);
            }
        }

        private async ValueTask<User> TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return await returningUserFunction();
            }
            catch (EmailDependencyException emailDependencyException)
            {
                throw CreateAndLogDependencyException(emailDependencyException);
            }
            catch (EmailServiceException emailServiceException)
            {
                throw CreateAndLogDependencyException(emailServiceException);
            }
            catch (UserDependencyException eserDependencyException)
            {
                throw CreateAndLogDependencyException(eserDependencyException);
            }
            catch (UserServiceException eserServiceException)
            {
                throw CreateAndLogDependencyException(eserServiceException);
            }
            catch (EmailDependencyValidationException emailDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(emailDependencyValidationException);
            }
            catch (EmailValidationException emailValidationException)
            {
                throw CreateAndLogDependencyValidationException(emailValidationException);
            }
            catch (UserDependencyValidationException eserDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(eserDependencyValidationException);
            }
            catch (UserValidationException eserValidationException)
            {
                throw CreateAndLogDependencyValidationException(eserValidationException);
            }
            catch (Exception exception)
            {
                var failedUserOrchestrationException =
                    new FailedUserOrchestrationException(exception);

                throw CreateAndLogServiceException(failedUserOrchestrationException);
            }
        }

        private UserTokenOrchestrationValidationException CreateAndLogValidationException(Xeption exception)
        {
            var userTokenOrchestrationValidationException = new UserTokenOrchestrationValidationException(exception);
            this.loggingBroker.LogError(userTokenOrchestrationValidationException);

            return userTokenOrchestrationValidationException;
        }

        private UserOrchestrationDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var userOrchestrationDependencyValidationException =
                new UserOrchestrationDependencyValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(userOrchestrationDependencyValidationException);

            return userOrchestrationDependencyValidationException; ;
        }

        private UserOrchestrationDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var userTokenOrchestrationDependencyException =
                new UserOrchestrationDependencyException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(userTokenOrchestrationDependencyException);

            return userTokenOrchestrationDependencyException;
        }

        private UserOrchestrationServiceException CreateAndLogServiceException(Xeption exception)
        {
            var userTokenOrchestrationServiceException =
                new UserOrchestrationServiceException(exception);

            this.loggingBroker.LogError(userTokenOrchestrationServiceException);

            return userTokenOrchestrationServiceException;
        }
    }
}
