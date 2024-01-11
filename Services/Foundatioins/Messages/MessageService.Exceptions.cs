using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Messages;
using dosLogistic.API.Models.Foundations.Messages.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xeptions;

namespace dosLogistic.API.Services.Foundatioins.Messages
{
    public partial class MessageService
    {
        private delegate ValueTask<Message> ReturningMessageFunction();
        private delegate IQueryable<Message> ReturningMessagesFunction();

        private async ValueTask<Message> TryCatch(ReturningMessageFunction returningMessageFunction)
        {
            try
            {
                return await returningMessageFunction();
            }
            catch (NullMessageException nullMessageException)
            {
                throw CreateAndLogValidationException(nullMessageException);
            }
            catch (InvalidMessageException invalidMessageException)
            {
                throw CreateAndLogValidationException(invalidMessageException);
            }
            catch (NotFoundMessageException notFoundMessageException)
            {
                throw CreateAndLogValidationException(notFoundMessageException);
            }
            catch (SqlException sqlException)
            {
                var failedMessageStorageException = new FailedMessageStorageException(sqlException);

                throw CreateAndLogValidationException(failedMessageStorageException);
            }
            catch (DuplicateKeyException dublicateKeyException)
            {
                var failedMessageDependencyValidationException =
                    new AlreadyExistsMessageException(dublicateKeyException);

                throw CreateAndLogValidationException(failedMessageDependencyValidationException);
            }
            catch (ForeignKeyConstraintConflictException foreignKeyConstraintConflictException)
            {
                var invalidMessageReferenceException =
                    new InvalidMessageReferenceException(foreignKeyConstraintConflictException);

                throw CreateAndLogValidationException(invalidMessageReferenceException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedMessageException = new LockedMessageException(dbUpdateConcurrencyException);

                throw CreateAndLogValidationException(lockedMessageException);
            }
            catch (DbUpdateException databaseUpdateException)
            {
                var failedMessageStorageException = new FailedMessageStorageException(databaseUpdateException);

                throw CreateAndLogDependencyException(failedMessageStorageException);
            }
            catch (Exception serviceException)
            {
                var failedServiceProfileException = new FailedMessageServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceProfileException);
            }
        }

        private IQueryable<Message> TryCatch(ReturningMessagesFunction returningMessagesFunction)
        {
            try
            {
                return returningMessagesFunction();
            }
            catch (SqlException sqlException)
            {
                var failedMessageServiceException = new FailedMessageServiceException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedMessageServiceException);
            }
            catch (Exception serviceException)
            {
                var failedServiceMessageException = new FailedMessageServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceMessageException);
            }
        }

        private MessageDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var messageDependencyException = new MessageDependencyException(exception);
            this.loggingBroker.LogError(messageDependencyException);

            return messageDependencyException;
        }

        private MessageServiceException CreateAndLogServiceException(Exception exception)
        {
            var messageServiceException = new MessageServiceException(exception);
            this.loggingBroker.LogError(messageServiceException);

            return messageServiceException;
        }

        private MessageDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var messageDependencyException = new MessageDependencyException(exception);
            this.loggingBroker.LogError(messageDependencyException);

            return messageDependencyException;
        }

        private MessageValidationException CreateAndLogValidationException(Xeption exception)
        {
            var messageValidationException = new MessageValidationException(exception);
            this.loggingBroker.LogError(messageValidationException);

            return messageValidationException;
        }
    }
}
