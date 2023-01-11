using Application.Functions.ServiceName.Commands.CreateServiceNameCommand;
using Application.Functions.ServiceName.Commands.DeleteServiceNameCommand;
using Application.Functions.ServiceName.Commands.UpdateServiceNameCommand;
using Application.Functions.ServiceName.Queries.GetServiceNameListQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceNameController : ControllerBase
    {
        private IMediator _mediator;

        public ServiceNameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic,Admin")]
        [Route("getServiceNames")]
        public async Task<IActionResult> GetServiceNames()
        {
            var serviceNames = await _mediator.Send(new GetServiceNameListQuery());
            return Ok(serviceNames);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createServiceName")]
        public async Task<IActionResult> CreateServiceName([FromBody] CreateServiceNameCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response.Id);
            }
            else if (response.Status == ResponseStatus.ValidationError)
            {
                return UnprocessableEntity(response.Message);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("updateServiceName")]
        public async Task<IActionResult> UpdateServiceName([FromBody] UpdateServiceNameCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok();
            }
            else if (response.Status == ResponseStatus.ValidationError && response.Message.Contains("does not exist"))
            {
                return NotFound(response.Message);
            }
            else if (response.Status == ResponseStatus.ValidationError)
            {
                return UnprocessableEntity(response.Message);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("deleteServiceName")]
        public async Task<IActionResult> DeleteServiceName([FromBody] DeleteServiceNameCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok();
            }
            else if (response.Status == ResponseStatus.ValidationError && response.Message.Contains("does not exist"))
            {
                return NotFound(response.Message);
            }
            else if (response.Status == ResponseStatus.ValidationError)
            {
                return UnprocessableEntity(response.Message);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
