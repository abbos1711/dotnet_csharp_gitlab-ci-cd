using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Parcels;

namespace dosLogistic.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Parcel> InsertParcelAsync(Parcel parcel);
        IQueryable<Parcel> SelectAllParcels();
        ValueTask<Parcel> SelectParcelByIdAsync(Guid id);
        ValueTask<Parcel> UpdateParcelAsync(Parcel parcel);
        ValueTask<Parcel> DeleteParcelAsync(Parcel parcel);
    }
}
