using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Brokers.DataTimes;
using dosLogistic.API.Brokers.Loggings;
using dosLogistic.API.Brokers.Storages;
using dosLogistic.API.Models.Foundations.Parcels;
using dosLogistic.API.Services.Processings.CurrentUserDetails;

namespace dosLogistic.API.Services.Foundatioins.Parcels
{
    public partial class ParcelService : IParcelSerivce
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public ParcelService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Parcel> AddParcelAsync(ParcelUserCreation parcel) =>
        TryCatch(async () =>
        {
            ValidateParcelOnAdd(parcel);

            return await this.storageBroker.InsertParcelAsync((Parcel)parcel);
        });

        public IQueryable<Parcel> RetrieveAllParcels() =>
        TryCatch(() => this.storageBroker.SelectAllParcels());

        public IQueryable<Parcel> RetrieveAllParcelsFromGerman() =>
        TryCatch(() => this.storageBroker.SelectAllParcels()
            .Where(x => x.ParcelCountry == ParcelCountry.German));

        public IQueryable<Parcel> RetrieveAllParcelsFromPoland() =>
        TryCatch(() => this.storageBroker.SelectAllParcels()
            .Where(x => x.ParcelCountry == ParcelCountry.Delaware));

        public IQueryable<Parcel> RetrieveParcelsByUserId() =>
        TryCatch(() => this.storageBroker.SelectAllParcels()
            .Where(x => x.UserId == CurrentUserDetaile.UserId()));



        public ValueTask<Parcel> RetrieveParcelByIdAsync(Guid parcelId) =>
        TryCatch(async () =>
        {
            ValidateParcelId(parcelId);

            Parcel maybeParcel =
                await this.storageBroker.SelectParcelByIdAsync(parcelId);

            return maybeParcel;
        });


        public ValueTask<Parcel> ModifyParcelAsync(ParcelUserCreation parcel) =>
        TryCatch(async () =>
        {
            ValidateParcelOnModify(parcel);

            Parcel maybeParcel =
                await this.storageBroker.SelectParcelByIdAsync(parcel.Id);
            ValidateAginstStorageParcelOnModify(inputParcel: parcel, storageParcel: maybeParcel);

            return await this.storageBroker.UpdateParcelAsync((Parcel)parcel);

        });

        public async ValueTask<Parcel> AddOrModifyParcelByAdminAsync(ParcelAdminCreation adminCreations)
        {
            Parcel maybeParcel =
                await this.storageBroker.SelectParcelByIdAsync(adminCreations.Id);

            maybeParcel.ParcelStatus =
                (adminCreations.ParcelStatus is null) ? maybeParcel.ParcelStatus : adminCreations.ParcelStatus.Value;

            maybeParcel.ServicePrice =
                (adminCreations.ServicePrice is null) ? maybeParcel.ServicePrice : adminCreations.ServicePrice;

            return await this.storageBroker.UpdateParcelAsync(maybeParcel);

        }

        public ValueTask<Parcel> RemoveParcelByIdAsync(Guid parcelId) =>
        TryCatch(async () =>
        {
            ValidateParcelId(parcelId);

            Parcel maybeParcel =
                await this.storageBroker.SelectParcelByIdAsync(parcelId);

            ValidateStorageParcel(maybeParcel, parcelId);

            return await this.storageBroker.DeleteParcelAsync(maybeParcel);
        });
    }
}
