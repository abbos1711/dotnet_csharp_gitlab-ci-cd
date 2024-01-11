using System;
using System.Linq;
using System.Threading.Tasks;
using dosLogistic.API.Models.Foundations.Messages;
using dosLogistic.API.Models.Foundations.Messages.Exceptions;
using dosLogistic.API.Services.Foundatioins.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RESTFulSense.Controllers;

namespace dosLogistic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : RESTFulController
    {
        private readonly IMessageService messageService;
        public MessagesController(IMessageService messageService) =>
            this.messageService = messageService;

        [HttpPost]
        public async ValueTask<ActionResult<Message>> PostMessageAsync(Message message)
        {
            try
            {
                return await this.messageService.AddMessageAsync(message);
            }
            catch (MessageValidationException messageValidationException)
            {
                return BadRequest(messageValidationException.InnerException);
            }
            catch (MessageDependencyException messageDependencyException)
            {
                return InternalServerError(messageDependencyException.InnerException);
            }
            catch (MessageServiceException messageServiceException)
            {
                return InternalServerError(messageServiceException.InnerException);
            }
        }

        [HttpGet]
        [EnableQuery]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public ActionResult<IQueryable<Message>> GetAllMessages()
        {
            try
            {
                IQueryable<Message> allMessages = this.messageService.RetrieveAllMessages();

                return Ok(allMessages);
            }
            catch (MessageDependencyException MessageDependencyException)
            {
                return InternalServerError(MessageDependencyException);
            }
            catch (MessageServiceException MessageServiceException)
            {
                return InternalServerError(MessageServiceException);
            }
        }

        [HttpGet("{messageId}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async ValueTask<ActionResult<Message>> GetMessageByIdAsync(Guid messageId)
        {
            try
            {
                return await this.messageService.RetrieveMessageByIdAsync(messageId);
            }
            catch (MessageDependencyException MessageDependencyException)
            {
                return InternalServerError(MessageDependencyException.InnerException);
            }
            catch (MessageValidationException MessageValidationException)
                when (MessageValidationException.InnerException is InvalidMessageException)
            {
                return BadRequest(MessageValidationException.InnerException);
            }
            catch (MessageValidationException MessageValidationException)
                when (MessageValidationException.InnerException is NotFoundMessageException)
            {
                return NotFound(MessageValidationException.InnerException);
            }
            catch (MessageServiceException MessageServiceException)
            {
                return InternalServerError(MessageServiceException.InnerException);
            }
        }

        [HttpDelete("{messageId}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async ValueTask<ActionResult<Message>> DeleteMessageByIdAsync(Guid messageId)
        {
            try
            {
                Message deletedMessage =
                    await this.messageService.RemoveMessageByIdAsync(messageId);

                return Ok(deletedMessage);
            }
            catch (MessageValidationException MessageValidationException)
                when (MessageValidationException.InnerException is NotFoundMessageException)
            {
                return NotFound(MessageValidationException.InnerException);
            }
            catch (MessageValidationException MessageValidationException)
            {
                return BadRequest(MessageValidationException.InnerException);
            }
            catch (MessageDependencyException MessageDependencyException)
            {
                return InternalServerError(MessageDependencyException.InnerException);
            }
            catch (MessageServiceException MessageServiceException)
            {
                return InternalServerError(MessageServiceException.InnerException);
            }
        }
    }
}
