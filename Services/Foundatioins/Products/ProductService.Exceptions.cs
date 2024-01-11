﻿using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Products;
using dosLogistic.API.Models.Foundations.Products.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xeptions;

namespace dosLogistic.API.Services.Foundatioins.Products
{
    public partial class ProductService
    {
        private delegate IQueryable<Product> ReturningProductsFunction();
        private delegate ValueTask<Product> ReturningProductFunction();

        private async ValueTask<Product> TryCatch(ReturningProductFunction returningProductFunction)
        {
            try
            {
                return await returningProductFunction();
            }
            catch (NullProductException nullProductException)
            {
                throw CreateAndLogValidationException(nullProductException);
            }
            catch (InvalidProductException invalidProductException)
            {
                throw CreateAndLogValidationException(invalidProductException);
            }
            catch (NotFoundProductException notFoundProductException)
            {
                throw CreateAndLogValidationException(notFoundProductException);
            }
            catch (SqlException sqlException)
            {
                var failedProductStorageException = new FailedProductStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedProductStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var failedProductDependencyValidationException =
                     new AlreadyExistsProductException(duplicateKeyException);

                throw CreateAndDependencyValidationException(failedProductDependencyValidationException);
            }
            catch (ForeignKeyConstraintConflictException foreignKeyConstraintConflictException)
            {
                var invalidProductReferenceException =
                    new InvalidProductReferenceException(foreignKeyConstraintConflictException);

                throw CreateAndDependencyValidationException(invalidProductReferenceException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedTickedException = new LockedProductException(dbUpdateConcurrencyException);

                throw CreateAndDependencyValidationException(lockedTickedException);
            }
            catch (DbUpdateException databaseUpdateException)
            {
                var failedProductStorageException = new FailedProductStorageException(databaseUpdateException);

                throw CreateAndLogDependencyException(failedProductStorageException);
            }
            catch (Exception serviceException)
            {
                var failedServiceProfileException = new FailedProductServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceProfileException);
            }
        }

        private IQueryable<Product> TryCatch(ReturningProductsFunction returningProductsFunction)
        {
            try
            {
                return returningProductsFunction();
            }
            catch (SqlException sqlException)
            {
                var failedProductServiceException = new FailedProductServiceException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedProductServiceException);
            }
            catch (Exception serviceException)
            {
                var failedServiceProductException = new FailedProductServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceProductException);
            }
        }

        private ProductDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var productDependencyException = new ProductDependencyException(exception);
            this.loggingBroker.LogError(productDependencyException);

            return productDependencyException;
        }

        private ProductServiceException CreateAndLogServiceException(Xeption exception)
        {
            var productServiceException = new ProductServiceException(exception);
            this.loggingBroker.LogError(productServiceException);

            return productServiceException;
        }

        private ProductValidationException CreateAndLogValidationException(Xeption exception)
        {
            var productValidationException = new ProductValidationException(exception);
            this.loggingBroker.LogError(productValidationException);

            return productValidationException;
        }

        private ProductDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var productDependencyException = new ProductDependencyException(exception);
            this.loggingBroker.LogCritical(productDependencyException);

            return productDependencyException;
        }

        private ProductDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
        {
            var productDependencyValidationException = new ProductDependencyValidationException(exception);
            this.loggingBroker.LogError(productDependencyValidationException);

            return productDependencyValidationException;
        }

    }
}
