using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Senders;
using dosLogistic.API.Models.Foundations.Senders.Exceptions;
using dosLogistic.API.Services.Foundatioins.Senders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RESTFulSense.Controllers;

namespace dosLogistic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendersController : RESTFulController
    {
        private readonly ISenderService senderService;
        public SendersController(ISenderService senderService) =>
        this.senderService = senderService;

        [HttpPost]
        [Authorize(Roles = "User")]
        public async ValueTask<ActionResult<Sender>> PostSenderAsync(Sender sender)
        {
            try
            {
                return await this.senderService.AddSenderAsync(sender);
            }
            catch (SenderValidationException senderValidationException)
            {
                return BadRequest(senderValidationException.InnerException);
            }
            catch (SenderDependencyValidationException senderDependencyValidationException)
                when (senderDependencyValidationException.InnerException is AlreadyExistsSenderException)
            {
                return Conflict(senderDependencyValidationException.InnerException);
            }
            catch (SenderDependencyValidationException senderDependencyValidationException)
            {
                return BadRequest(senderDependencyValidationException.InnerException);
            }
            catch (SenderDependencyException senderDependencyException)
            {
                return InternalServerError(senderDependencyException.InnerException);
            }
            catch (SenderServiceException senderServiceException)
            {
                return InternalServerError(senderServiceException.InnerException);
            }
        }

        [HttpGet]
        [EnableQuery]
        [Authorize(Roles = "User")]
        public ActionResult<IQueryable<Sender>> GetSendersByUserId()
        {
            try
            {
                IQueryable<Sender> allSenders = this.senderService.RetrieveSendersByUserId();

                return Ok(allSenders);
            }
            catch (SenderDependencyException senderDependencyException)
            {
                return InternalServerError(senderDependencyException.InnerException);
            }
            catch (SenderServiceException senderServiceException)
            {
                return InternalServerError(senderServiceException.InnerException);
            }
        }

        [HttpGet("{senderId}")]
        [Authorize]
        public async ValueTask<ActionResult<Sender>> GetSenderByIdAsync(Guid senderId)
        {
            try
            {
                return await this.senderService.RetrieveSenderByIdAsync(senderId);
            }
            catch (SenderDependencyException senderDependencyException)
            {
                return InternalServerError(senderDependencyException.InnerException);
            }
            catch (SenderValidationException senderValidationException)
                when (senderValidationException.InnerException is InvalidSenderException)
            {
                return BadRequest(senderValidationException.InnerException);
            }
            catch (SenderValidationException senderValidationException)
                when (senderValidationException.InnerException is NotFoundSenderException)
            {
                return NotFound(senderValidationException.InnerException);
            }
            catch (SenderServiceException senderServiceException)
            {
                return InternalServerError(senderServiceException.InnerException);
            }
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        public async ValueTask<ActionResult<Sender>> PutSenderAsync(Sender sender)
        {
            try
            {
                Sender modifiedSender =
                    await this.senderService.ModifySenderAsync(sender);

                return Ok(modifiedSender);
            }
            catch (SenderValidationException senderValidationException)
                when (senderValidationException.InnerException is NotFoundSenderException)
            {
                return NotFound(senderValidationException.InnerException);
            }
            catch (SenderValidationException senderValidationException)
            {
                return BadRequest(senderValidationException.InnerException);
            }
            catch (SenderDependencyValidationException senderDependencyValidationException)
            {
                return BadRequest(senderDependencyValidationException.InnerException);
            }
            catch (SenderDependencyException senderDependencyException)
            {
                return InternalServerError(senderDependencyException.InnerException);
            }
            catch (SenderServiceException senderServiceException)
            {
                return InternalServerError(senderServiceException.InnerException);
            }
        }

        [HttpDelete("{senderId}")]
        [Authorize]
        public async ValueTask<ActionResult<Sender>> DeleteSenderByIdAsync(Guid senderId)
        {
            try
            {
                Sender deletedSender =
                    await this.senderService.RemoveSenderByIdAsync(senderId);

                return Ok(deletedSender);
            }
            catch (SenderValidationException senderValidationException)
                when (senderValidationException.InnerException is NotFoundSenderException)
            {
                return NotFound(senderValidationException.InnerException);
            }
            catch (SenderValidationException senderValidationException)
            {
                return BadRequest(senderValidationException.InnerException);
            }
            catch (SenderDependencyValidationException senderDependencyValidationException)
                when (senderDependencyValidationException.InnerException is LockedSenderException)
            {
                return Locked(senderDependencyValidationException.InnerException);
            }
            catch (SenderDependencyValidationException senderDependencyValidationException)
            {
                return BadRequest(senderDependencyValidationException.InnerException);
            }
            catch (SenderDependencyException senderDependencyException)
            {
                return InternalServerError(senderDependencyException.InnerException);
            }
            catch (SenderServiceException senderServiceException)
            {
                return InternalServerError(senderServiceException.InnerException);
            }
        }
    }
}
