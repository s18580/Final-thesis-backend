using Application.Functions.Service.Commands.CreateServiceCommand;
using Application.Functions.Service.Commands.DeleteServiceCommand;
using Application.Functions.Service.Commands.UpdateServiceCommand;
using Application.Functions.Service.Queries.GetServiceListByOrderItemQuery;
using Application.Functions.Service.Queries.GetServiceListByValuationQuery;
using Application.Functions.Service.Queries.GetServiceQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getServicesByOrderItem")]
        public async Task<IActionResult> GetServicesByOrderItem([FromQuery] int id)
        {
            var services = await _mediator.Send(new GetServiceListByOrderItemQuery { IdOrderItem = id });
            return Ok(services);
        }

        [HttpGet]
        [Route("getServicesByValuation")]
        public async Task<IActionResult> GetServicesByValuation([FromQuery] int id)
        {
            var services = await _mediator.Send(new GetServiceListByValuationQuery { IdValuation = id });
            return Ok(services);
        }

        [HttpGet]
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

        [HttpPost]
        [Route("createService")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok();
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

        [HttpPost]
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

        [HttpDelete]
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
