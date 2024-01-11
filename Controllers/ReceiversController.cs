using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Receivers;
using dosLogistic.API.Models.Foundations.Receivers.Exceptions;
using dosLogistic.API.Services.Foundatioins.Receivers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RESTFulSense.Controllers;

namespace dosLogistic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiversController : RESTFulController
    {
        private readonly IReceiverService receiverService;
        public ReceiversController(IReceiverService receiverService) =>
            this.receiverService = receiverService;

        [HttpPost]
        [Authorize]
        public async ValueTask<ActionResult<Receiver>> PostReceiverAsync(Receiver receiver)
        {
            try
            {
                return await this.receiverService.AddReceiverAsync(receiver);
            }
            catch (ReceiverValidationException receiverValidationException)
            {
                return BadRequest(receiverValidationException.InnerException);
            }
            catch (ReceiverDependencyValidationException receiverDependencyValidationException)
                when (receiverDependencyValidationException.InnerException is AlreadyExistsReceiverException)
            {
                return Conflict(receiverDependencyValidationException.InnerException);
            }
            catch (ReceiverDependencyValidationException receiverDependencyValidationException)
            {
                return BadRequest(receiverDependencyValidationException.InnerException);
            }
            catch (ReceiverDependencyException receiverDependencyException)
            {
                return InternalServerError(receiverDependencyException.InnerException);
            }
            catch (ReceiverServiceException receiverServiceException)
            {
                return InternalServerError(receiverServiceException.InnerException);
            }
        }

        [HttpGet]
        [EnableQuery]
        [Authorize(Roles = "User")]
        public ActionResult<IQueryable<Receiver>> GetReceiversByUserId()
        {
            try
            {
                IQueryable<Receiver> allReceivers = this.receiverService.RetrieveReceiversByUserId();

                return Ok(allReceivers);
            }
            catch (ReceiverDependencyException receiverDependencyException)
            {
                return InternalServerError(receiverDependencyException.InnerException);
            }
            catch (ReceiverServiceException receiverServiceException)
            {
                return InternalServerError(receiverServiceException.InnerException);
            }
        }

        [HttpGet("{receiverId}")]
        [Authorize]
        public async ValueTask<ActionResult<Receiver>> GetReceiverByIdAsync(Guid receiverId)
        {
            try
            {
                return await this.receiverService.RetrieveReceiverByIdAsync(receiverId);
            }
            catch (ReceiverDependencyException receiverDependencyException)
            {
                return InternalServerError(receiverDependencyException.InnerException);
            }
            catch (ReceiverValidationException receiverValidationException)
                when (receiverValidationException.InnerException is InvalidReceiverException)
            {
                return BadRequest(receiverValidationException.InnerException);
            }
            catch (ReceiverValidationException receiverValidationException)
                when (receiverValidationException.InnerException is NotFoundReceiverException)
            {
                return NotFound(receiverValidationException.InnerException);
            }
            catch (ReceiverServiceException receiverServiceException)
            {
                return InternalServerError(receiverServiceException.InnerException);
            }
        }

        [HttpPut]
        [Authorize]
        public async ValueTask<ActionResult<Receiver>> PutReceiverAsync(Receiver receiver)
        {
            try
            {
                Receiver modifiedReceiver =
                    await this.receiverService.ModifyReceiverAsync(receiver);

                return Ok(modifiedReceiver);
            }
            catch (ReceiverValidationException receiverValidationException)
                when (receiverValidationException.InnerException is NotFoundReceiverException)
            {
                return NotFound(receiverValidationException.InnerException);
            }
            catch (ReceiverValidationException receiverValidationException)
            {
                return BadRequest(receiverValidationException.InnerException);
            }
            catch (ReceiverDependencyValidationException receiverDependencyValidationException)
            {
                return BadRequest(receiverDependencyValidationException.InnerException);
            }
            catch (ReceiverDependencyException receiverDependencyException)
            {
                return InternalServerError(receiverDependencyException.InnerException);
            }
            catch (ReceiverServiceException receiverServiceException)
            {
                return InternalServerError(receiverServiceException.InnerException);
            }
        }

        [HttpDelete("{receiverId}")]
        [Authorize]
        public async ValueTask<ActionResult<Receiver>> DeleteReceiverByIdAsync(Guid receiverId)
        {
            try
            {
                Receiver deletedReceiver =
                    await this.receiverService.RemoveReceiverByIdAsync(receiverId);

                return Ok(deletedReceiver);
            }
            catch (ReceiverValidationException receiverValidationException)
                when (receiverValidationException.InnerException is NotFoundReceiverException)
            {
                return NotFound(receiverValidationException.InnerException);
            }
            catch (ReceiverValidationException receiverValidationException)
            {
                return BadRequest(receiverValidationException.InnerException);
            }
            catch (ReceiverDependencyValidationException receiverDependencyValidationException)
                when (receiverDependencyValidationException.InnerException is LockedReceiverException)
            {
                return Locked(receiverDependencyValidationException.InnerException);
            }
            catch (ReceiverDependencyValidationException receiverDependencyValidationException)
            {
                return BadRequest(receiverDependencyValidationException.InnerException);
            }
            catch (ReceiverDependencyException receiverDependencyException)
            {
                return InternalServerError(receiverDependencyException.InnerException);
            }
            catch (ReceiverServiceException receiverServiceException)
            {
                return InternalServerError(receiverServiceException.InnerException);
            }
        }
    }
}
