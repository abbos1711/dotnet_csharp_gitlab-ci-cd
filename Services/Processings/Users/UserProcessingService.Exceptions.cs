using dosLogistic.API.Models.Foundations.Users;
using dosLogistic.API.Models.Foundations.Users.Exceptions;
using dosLogistic.API.Models.Processings.Users;
using Xeptions;

namespace dosLogistic.API.Services.Processings.Users
{
    public partial class UserProcessingService
    {
        private delegate User ReturningUserFunction();

        private User TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return returningUserFunction();
            }
            catch (InvalidUserProcessingException invalidUserProcessingException)
            {
                throw CreateAndLogValidationException(invalidUserProcessingException);
            }
            catch (UserDependencyException userDependencyException)
            {
                throw CreateAndLogDependencyException(userDependencyException);
            }
            catch (UserServiceException userServiceException)
            {
                throw CreateAndLogDependencyException(userServiceException);
            }
        }

        private UserProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var userProcessingValidationException =
                new UserProcessingValidationException(exception);

            this.loggingBroker.LogError(userProcessingValidationException);

            return userProcessingValidationException;
        }

        private UserProcessingDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var userProcessingDependencyException =
                new UserProcessingDependencyException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(userProcessingDependencyException);

            return userProcessingDependencyException;
        }
    }
}
