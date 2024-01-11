using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Parcels;
using dosLogistic.API.Models.Foundations.Parcels.Exceptions;
using dosLogistic.API.Models.Foundations.Receivers.Exceptions;
using dosLogistic.API.Services.Foundatioins.Parcels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RESTFulSense.Controllers;

namespace dosLogistic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelsController : RESTFulController
    {
        private readonly IParcelSerivce parcelService;
        public ParcelsController(IParcelSerivce parcelService) =>
        this.parcelService = parcelService;


        [HttpPost]
        [Authorize(Roles = "User")]
        public async ValueTask<ActionResult<Parcel>> PostParcelAsync(ParcelUserCreation parcel)
        {
            try
            {
                return await this.parcelService.AddParcelAsync(parcel);
            }
            catch (ParcelValidationException ParcelValidationExpection)
            {
                return BadRequest(ParcelValidationExpection.InnerException);
            }
            catch (ParcelDependencyValidationException ParcelDependencyValidationException)
                when (ParcelDependencyValidationException.InnerException is AlreadyExistsParcelException)
            {
                return Conflict(ParcelDependencyValidationException.InnerException);
            }
            catch (ParcelDependencyValidationException ParcelDependencyValidationException)
            {
                return BadRequest(ParcelDependencyValidationException.InnerException);
            }
            catch (ParcelDependencyException ParcelDependencyException)
            {
                return InternalServerError(ParcelDependencyException.InnerException);
            }
            catch (ParcelServiceException ParcelServiceException)
            {
                return InternalServerError(ParcelServiceException.InnerException);
            }
        }

        [HttpGet("GetAllParcels")]
        [EnableQuery]
        [Authorize(Roles = "GermanAdmin,PolandAdmin,Admin,SuperAdmin")]
        public ActionResult<IQueryable<Parcel>> GetAllParcels()
        {
            try
            {
                IQueryable<Parcel> allParcels = this.parcelService.RetrieveAllParcels();

                return Ok(allParcels);
            }
            catch (ParcelDependencyException ParcelDependencyException)
            {
                return InternalServerError(ParcelDependencyException.InnerException);
            }
            catch (ParcelServiceException ParcelServiceException)
            {
                return InternalServerError(ParcelServiceException.InnerException);
            }
        }

        [HttpGet("GetAllParcelsFromPoland")]
        [EnableQuery]
        [Authorize(Roles = "GermanAdmin,PolandAdmin,Admin,SuperAdmin")]
        public ActionResult<IQueryable<Parcel>> GetAllParcelsFromPoland()
        {
            try
            {
                IQueryable<Parcel> allParcels = this.parcelService.RetrieveAllParcelsFromPoland();

                return Ok(allParcels);
            }
            catch (ParcelDependencyException ParcelDependencyException)
            {
                return InternalServerError(ParcelDependencyException.InnerException);
            }
            catch (ParcelServiceException ParcelServiceException)
            {
                return InternalServerError(ParcelServiceException.InnerException);
            }
        }

        [HttpGet("GetAllParcelsFromGerman")]
        [EnableQuery]
        [Authorize(Roles = "GermanAdmin,PolandAdmin,Admin,SuperAdmin")]
        public ActionResult<IQueryable<Parcel>> GetAllParcelsFromGerman()
        {
            try
            {
                IQueryable<Parcel> allParcels = this.parcelService.RetrieveAllParcelsFromGerman();

                return Ok(allParcels);
            }
            catch (ParcelDependencyException ParcelDependencyException)
            {
                return InternalServerError(ParcelDependencyException.InnerException);
            }
            catch (ParcelServiceException ParcelServiceException)
            {
                return InternalServerError(ParcelServiceException.InnerException);
            }
        }

        [HttpGet("GetParcelsByUserId")]
        [EnableQuery]
        [Authorize]
        public ActionResult<IQueryable<Parcel>> GetParcelsByUserId()
        {
            try
            {
                IQueryable<Parcel> allParcels = this.parcelService.RetrieveParcelsByUserId();

                return Ok(allParcels);
            }
            catch (ParcelDependencyException ParcelDependencyException)
            {
                return InternalServerError(ParcelDependencyException.InnerException);
            }
            catch (ParcelServiceException ParcelServiceException)
            {
                return InternalServerError(ParcelServiceException.InnerException);
            }
        }

        [HttpGet("{parcelId}")]
        [Authorize]
        public async ValueTask<ActionResult<Parcel>> GetParcelByIdAsync(Guid parcelId)
        {
            try
            {
                return await this.parcelService.RetrieveParcelByIdAsync(parcelId);
            }
            catch (ParcelDependencyException ParcelDependencyException)
            {
                return InternalServerError(ParcelDependencyException.InnerException);
            }
            catch (ParcelValidationException ParcelValidationException)
                when (ParcelValidationException.InnerException is InvalidParcelException)
            {
                return BadRequest(ParcelValidationException.InnerException);
            }
            catch (ParcelValidationException ParcelValidationException)
                when (ParcelValidationException.InnerException is NotFoundParcelException)
            {
                return NotFound(ParcelValidationException.InnerException);
            }
            catch (ParcelServiceException ParcelServiceException)
            {
                return InternalServerError(ParcelServiceException.InnerException);
            }
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        public async ValueTask<ActionResult<Parcel>> PutParcelAsync(ParcelUserCreation Parcel)
        {
            try
            {
                Parcel modifiedParcel =
                    await this.parcelService.ModifyParcelAsync(Parcel);

                return Ok(modifiedParcel);
            }
            catch (ParcelValidationException ParcelValidationException)
                when (ParcelValidationException.InnerException is NotFoundParcelException)
            {
                return NotFound(ParcelValidationException.InnerException);
            }
            catch (ParcelValidationException ParcelValidationException)
            {
                return BadRequest(ParcelValidationException.InnerException);
            }
            catch (ParcelDependencyValidationException ParcelDependencyValidationException)
            {
                return BadRequest(ParcelDependencyValidationException.InnerException);
            }
            catch (ParcelDependencyException ParcelDependencyException)
            {
                return InternalServerError(ParcelDependencyException.InnerException);
            }
            catch (ParcelServiceException ParcelServiceException)
            {
                return InternalServerError(ParcelServiceException.InnerException);
            }
        }

        [HttpPatch("adminCreationsForParcel")]
        [Authorize(Roles = "GermanAdmin,PolandAdmin,Admin,SuperAdmin")]
        public async ValueTask<ActionResult<Parcel>> PatchParcelAdminCreationAsync([FromForm] ParcelAdminCreation adminCreations)
        {
            try
            {
                Parcel modifiedParcel =
                    await this.parcelService.AddOrModifyParcelByAdminAsync(adminCreations);

                return Ok(modifiedParcel);
            }
            catch (ParcelValidationException parcelValidationException)
                when (parcelValidationException.InnerException is NotFoundParcelException)
            {
                return NotFound(parcelValidationException.InnerException);
            }
            catch (ParcelValidationException parcelValidationException)
            {
                return BadRequest(parcelValidationException.InnerException);
            }
            catch (ParcelDependencyValidationException parcelDependencyValidationException)
            {
                return BadRequest(parcelDependencyValidationException.InnerException);
            }
            catch (ParcelDependencyException parcelDependencyException)
            {
                return InternalServerError(parcelDependencyException.InnerException);
            }
            catch (ParcelServiceException parcelServiceException)
            {
                return InternalServerError(parcelServiceException.InnerException);
            }
        }

        [HttpDelete("{parcelId}")]
        [Authorize]
        public async ValueTask<ActionResult<Parcel>> DeleteParcelByIdAsync(Guid parcelId)
        {
            try
            {
                Parcel deletedParcel =
                    await this.parcelService.RemoveParcelByIdAsync(parcelId);

                return Ok(deletedParcel);
            }
            catch (ParcelValidationException ParcelValidationException)
                when (ParcelValidationException.InnerException is NotFoundParcelException)
            {
                return NotFound(ParcelValidationException.InnerException);
            }
            catch (ParcelValidationException ParcelValidationException)
            {
                return BadRequest(ParcelValidationException.InnerException);
            }
            catch (ParcelDependencyValidationException ParcelDependencyValidationException)
                when (ParcelDependencyValidationException.InnerException is LockedParcelException)
            {
                return Locked(ParcelDependencyValidationException.InnerException);
            }
            catch (ParcelDependencyValidationException ParcelDependencyValidationException)
            {
                return BadRequest(ParcelDependencyValidationException.InnerException);
            }
            catch (ParcelDependencyException ParcelDependencyException)
            {
                return InternalServerError(ParcelDependencyException.InnerException);
            }
            catch (ParcelServiceException ParcelServiceException)
            {
                return InternalServerError(ParcelServiceException.InnerException);
            }
        }
    }
}
