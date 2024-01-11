using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Parcels;
using Microsoft.EntityFrameworkCore;

namespace dosLogistic.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Parcel> Parcels { get; set; }

        public async ValueTask<Parcel> InsertParcelAsync(Parcel parcel) =>
            await InsertAsync(parcel);

        public IQueryable<Parcel> SelectAllParcels() =>
            SelectAll<Parcel>();

        public async ValueTask<Parcel> SelectParcelByIdAsync(Guid id) =>
            await SelectAsync<Parcel>(id);

        public async ValueTask<Parcel> UpdateParcelAsync(Parcel parcel) =>
            await UpdateAsync(parcel);

        public async ValueTask<Parcel> DeleteParcelAsync(Parcel parcel) =>
            await DeleteAsync(parcel);
    }
}
