using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Parcels;

namespace dosLogistic.API.Services.Foundatioins.Parcels
{
    public interface IParcelSerivce
    {
        ValueTask<Parcel> AddParcelAsync(ParcelUserCreation parcel);
        IQueryable<Parcel> RetrieveAllParcels();
        IQueryable<Parcel> RetrieveAllParcelsFromGerman();
        IQueryable<Parcel> RetrieveAllParcelsFromPoland();
        IQueryable<Parcel> RetrieveParcelsByUserId();
        ValueTask<Parcel> RetrieveParcelByIdAsync(Guid parcelId);
        ValueTask<Parcel> ModifyParcelAsync(ParcelUserCreation parcel);
        ValueTask<Parcel> RemoveParcelByIdAsync(Guid parcelId);
        ValueTask<Parcel> AddOrModifyParcelByAdminAsync(ParcelAdminCreation adminCreations);
    }
}
