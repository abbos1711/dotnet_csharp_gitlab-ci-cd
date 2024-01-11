using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Receivers;
using dosLogistic.API.Models.Foundations.Receivers.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xeptions;

namespace dosLogistic.API.Services.Foundatioins.Receivers
{
    public partial class ReceiverService
    {
        private delegate IQueryable<Receiver> ReturningReceiversFunction();
        private delegate ValueTask<Receiver> ReturningReceiverFunction();

        private async ValueTask<Receiver> TryCatch(ReturningReceiverFunction returningReceiverFunction)
        {
            try
            {
                return await returningReceiverFunction();
            }
            catch (NullReceiverException nullReceiverException)
            {
                throw CreateAndLogValidationException(nullReceiverException);
            }
            catch (InvalidReceiverException invalidReceiverException)
            {
                throw CreateAndLogValidationException(invalidReceiverException);
            }
            catch (NotFoundReceiverException notFoundReceiverException)
            {
                throw CreateAndLogValidationException(notFoundReceiverException);
            }
            catch (SqlException sqlException)
            {
                var failedReceiverStorageException = new FailedReceiverStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedReceiverStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var failedReceiverDependencyValidationException =
                     new AlreadyExistsReceiverException(duplicateKeyException);

                throw CreateAndDependencyValidationException(failedReceiverDependencyValidationException);
            }
            catch (ForeignKeyConstraintConflictException foreignKeyConstraintConflictException)
            {
                var invalidReceiverReferenceException =
                    new InvalidReceiverReferenceException(foreignKeyConstraintConflictException);

                throw CreateAndDependencyValidationException(invalidReceiverReferenceException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedTickedException = new LockedReceiverException(dbUpdateConcurrencyException);

                throw CreateAndDependencyValidationException(lockedTickedException);
            }
            catch (DbUpdateException databaseUpdateException)
            {
                var failedReceiverStorageException = new FailedReceiverStorageException(databaseUpdateException);

                throw CreateAndLogDependencyException(failedReceiverStorageException);
            }
            catch (Exception serviceException)
            {
                var failedServiceProfileException = new FailedReceiverServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceProfileException);
            }
        }

        private IQueryable<Receiver> TryCatch(ReturningReceiversFunction returningReceiversFunction)
        {
            try
            {
                return returningReceiversFunction();
            }
            catch (SqlException sqlException)
            {
                var failedReceiverServiceException = new FailedReceiverServiceException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedReceiverServiceException);
            }
            catch (Exception serviceException)
            {
                var failedServiceReceiverException = new FailedReceiverServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceReceiverException);
            }
        }

        private ReceiverDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var ticketDependencyException = new ReceiverDependencyException(exception);
            this.loggingBroker.LogError(ticketDependencyException);

            return ticketDependencyException;
        }

        private ReceiverServiceException CreateAndLogServiceException(Xeption exception)
        {
            var ticketServiceException = new ReceiverServiceException(exception);
            this.loggingBroker.LogError(ticketServiceException);

            return ticketServiceException;
        }

        private ReceiverValidationException CreateAndLogValidationException(Xeption exception)
        {
            var ticketValidationException = new ReceiverValidationException(exception);
            this.loggingBroker.LogError(ticketValidationException);

            return ticketValidationException;
        }

        private ReceiverDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var ticketDependencyException = new ReceiverDependencyException(exception);
            this.loggingBroker.LogCritical(ticketDependencyException);

            return ticketDependencyException;
        }

        private ReceiverDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
        {
            var ticketDependencyValidationException = new ReceiverDependencyValidationException(exception);
            this.loggingBroker.LogError(ticketDependencyValidationException);

            return ticketDependencyValidationException;
        }
    }
}