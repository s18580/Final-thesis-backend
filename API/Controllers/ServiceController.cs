using Application.Functions.Service.Commands.CreateServiceCommand;
using Application.Functions.Service.Commands.DeleteServiceCommand;
using Application.Functions.Service.Commands.UpdateServiceCommand;
using Application.Functions.Service.Queries.GetServiceListByOrderItemQuery;
using Application.Functions.Service.Queries.GetServiceListByValuationQuery;
using Application.Functions.Service.Queries.GetServiceQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getServicesByOrderItem")]
        public async Task<IActionResult> GetServicesByOrderItem([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetServiceListByOrderItemQuery { IdOrderItem = id });
            if (response.Success)
            {
                return Ok(response.services);
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

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getServicesByValuation")]
        public async Task<IActionResult> GetServicesByValuation([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetServiceListByValuationQuery { IdValuation = id });
            if (response.Success)
            {
                return Ok(response.services);
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

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getService")]
        public async Task<IActionResult> GetService([FromQuery] int id)
        {
            var service = await _mediator.Send(new GetServiceQuery { IdService = id });
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createService")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
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

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("updateService")]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand command)
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

        [HttpDelete, Authorize(Roles = "Basic")]
        [Route("deleteService")]
        public async Task<IActionResult> DeleteService([FromBody] DeleteServiceCommand command)
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
