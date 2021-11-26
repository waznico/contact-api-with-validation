using System;
using System.Net;
using System.Threading.Tasks;
using ContactService.Application.Mediator.Commands;
using ContactService.Exceptions;
using ContactService.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddContactForm(ContactFormRequest request)
        {
            try
            {
                var addContactCommand = new AddContactRequestCommand(request.FirstName, request.LastName, request.MailAddress, request.Message);
                var result = await _mediator.Send(addContactCommand);
                return Ok(result);
            }
            catch (MediatorValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
