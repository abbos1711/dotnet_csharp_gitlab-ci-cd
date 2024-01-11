using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Parcels;
using dosLogistic.API.Models.Foundations.Parcels.Exceptions;
using dosLogistic.API.Models.Foundations.Receivers.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xeptions;

namespace dosLogistic.API.Services.Foundatioins.Parcels
{
    public partial class ParcelService
    {
        private delegate IQueryable<Parcel> ReturningParcelsFunction();
        private delegate ValueTask<Parcel> ReturningParcelFunction();

        private async ValueTask<Parcel> TryCatch(ReturningParcelFunction returningParcelFunction)
        {
            try
            {
                return await returningParcelFunction();
            }
            catch (NullParcelException nullParcelException)
            {
                throw CreateAndLogValidationException(nullParcelException);
            }
            catch (InvalidParcelException invalidParcelException)
            {
                throw CreateAndLogValidationException(invalidParcelException);
            }
            catch (NotFoundParcelException notFoundParcelException)
            {
                throw CreateAndLogValidationException(notFoundParcelException);
            }
            catch (SqlException sqlException)
            {
                var failedParcelStorageException = new FailedParcelStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedParcelStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var failedParcelDependencyValidationException =
                     new AlreadyExistsParcelException(duplicateKeyException);

                throw CreateAndDependencyValidationException(failedParcelDependencyValidationException);
            }
            catch (ForeignKeyConstraintConflictException foreignKeyConstraintConflictException)
            {
                var invalidParcelReferenceException =
                    new InvalidParcelReferenceException(foreignKeyConstraintConflictException);

                throw CreateAndDependencyValidationException(invalidParcelReferenceException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedTickedException = new LockedParcelException(dbUpdateConcurrencyException);

                throw CreateAndDependencyValidationException(lockedTickedException);
            }
            catch (DbUpdateException databaseUpdateException)
            {
                var failedParcelStorageException = new FailedParcelStorageException(databaseUpdateException);

                throw CreateAndLogDependencyException(failedParcelStorageException);
            }
            catch (Exception serviceException)
            {
                var failedServiceProfileException = new FailedParcelServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceProfileException);
            }
        }

        private IQueryable<Parcel> TryCatch(ReturningParcelsFunction returningParcelsFunction)
        {
            try
            {
                return returningParcelsFunction();
            }
            catch (SqlException sqlException)
            {
                var failedParcelServiceException = new FailedParcelServiceException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedParcelServiceException);
            }
            catch (Exception serviceException)
            {
                var failedServiceParcelException = new FailedParcelServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceParcelException);
            }
        }

        private ParcelDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var ParcelDependencyException = new ParcelDependencyException(exception);
            this.loggingBroker.LogError(ParcelDependencyException);

            return ParcelDependencyException;
        }

        private ParcelServiceException CreateAndLogServiceException(Xeption exception)
        {
            var ParcelServiceException = new ParcelServiceException(exception);
            this.loggingBroker.LogError(ParcelServiceException);

            return ParcelServiceException;
        }

        private ParcelValidationException CreateAndLogValidationException(Xeption exception)
        {
            var ParcelValidationException = new ParcelValidationException(exception);
            this.loggingBroker.LogError(ParcelValidationException);

            return ParcelValidationException;
        }

        private ParcelDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var ParcelDependencyException = new ParcelDependencyException(exception);
            this.loggingBroker.LogCritical(ParcelDependencyException);

            return ParcelDependencyException;
        }

        private ParcelDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
        {
            var ParcelDependencyValidationException = new ParcelDependencyValidationException(exception);
            this.loggingBroker.LogError(ParcelDependencyValidationException);

            return ParcelDependencyValidationException;
        }
    }
}
