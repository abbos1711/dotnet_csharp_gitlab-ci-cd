using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Senders;
using dosLogistic.API.Models.Foundations.Senders.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xeptions;

namespace dosLogistic.API.Services.Foundatioins.Senders
{
    public partial class SenderService
    {
        private delegate IQueryable<Sender> ReturningSendersFunction();
        private delegate ValueTask<Sender> ReturningSenderFunction();

        private async ValueTask<Sender> TryCatch(ReturningSenderFunction returningSenderFunction)
        {
            try
            {
                return await returningSenderFunction();
            }
            catch (NullSenderException nullSenderException)
            {
                throw CreateAndLogValidationException(nullSenderException);
            }
            catch (InvalidSenderException invalidSenderException)
            {
                throw CreateAndLogValidationException(invalidSenderException);
            }
            catch (NotFoundSenderException notFoundSenderException)
            {
                throw CreateAndLogValidationException(notFoundSenderException);
            }
            catch (SqlException sqlException)
            {
                var failedSenderStorageException = new FailedSenderStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedSenderStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var failedSenderDependencyValidationException =
                     new AlreadyExistsSenderException(duplicateKeyException);

                throw CreateAndDependencyValidationException(failedSenderDependencyValidationException);
            }
            catch (ForeignKeyConstraintConflictException foreignKeyConstraintConflictException)
            {
                var invalidSenderReferenceException =
                    new InvalidSenderReferenceException(foreignKeyConstraintConflictException);

                throw CreateAndDependencyValidationException(invalidSenderReferenceException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedTickedException = new LockedSenderException(dbUpdateConcurrencyException);

                throw CreateAndDependencyValidationException(lockedTickedException);
            }
            catch (DbUpdateException databaseUpdateException)
            {
                var failedSenderStorageException = new FailedSenderStorageException(databaseUpdateException);

                throw CreateAndLogDependencyException(failedSenderStorageException);
            }
            catch (Exception serviceException)
            {
                var failedServiceProfileException = new FailedSenderServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceProfileException);
            }
        }

        private IQueryable<Sender> TryCatch(ReturningSendersFunction returningSendersFunction)
        {
            try
            {
                return returningSendersFunction();
            }
            catch (SqlException sqlException)
            {
                var failedSenderServiceException = new FailedSenderServiceException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedSenderServiceException);
            }
            catch (Exception serviceException)
            {
                var failedServiceSenderException = new FailedSenderServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceSenderException);
            }
        }

        private SenderDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var ticketDependencyException = new SenderDependencyException(exception);
            this.loggingBroker.LogError(ticketDependencyException);

            return ticketDependencyException;
        }

        private SenderServiceException CreateAndLogServiceException(Xeption exception)
        {
            var ticketServiceException = new SenderServiceException(exception);
            this.loggingBroker.LogError(ticketServiceException);

            return ticketServiceException;
        }

        private SenderValidationException CreateAndLogValidationException(Xeption exception)
        {
            var ticketValidationException = new SenderValidationException(exception);
            this.loggingBroker.LogError(ticketValidationException);

            return ticketValidationException;
        }

        private SenderDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var ticketDependencyException = new SenderDependencyException(exception);
            this.loggingBroker.LogCritical(ticketDependencyException);

            return ticketDependencyException;
        }

        private SenderDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
        {
            var ticketDependencyValidationException = new SenderDependencyValidationException(exception);
            this.loggingBroker.LogError(ticketDependencyValidationException);

            return ticketDependencyValidationException;
        }
    }
}