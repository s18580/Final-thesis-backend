using Application.Functions.DeliveriesAddresses.Commands.CreateDeliveriesAddressesCommand;
using Application.Functions.DeliveriesAddresses.Commands.DeleteDeliveriesAddressesCommand;
using Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByAddressQuery;
using Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByOrderQuery;
using Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListBySupplyQuery;
using Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesQuery;
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
    public class DeliveriesAddressesController : ControllerBase
    {
        private IMediator _mediator;

        public DeliveriesAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getDeliveriesAddressesByOrder")]
        public async Task<IActionResult> GetDeliveriesAddressesByOrder([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetDeliveriesAddressesListByOrderQuery { IdOrder = id });
            if (response.Success)
            {
                return Ok(response.deliveriesAddresses);
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
        [Route("getDeliveriesAddressesBySupply")]
        public async Task<IActionResult> GetDeliveriesAddressesBySupply([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetDeliveriesAddressesListBySupplyQuery { IdSupply = id });
            if (response.Success)
            {
                return Ok(response.deliveriesAddresses);
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
        [Route("getDeliveriesAddressesByAddress")]
        public async Task<IActionResult> GetDeliveriesAddressesByAddress([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetDeliveriesAddressesListByAddressQuery { IdAddress = id });
            if (response.Success)
            {
                return Ok(response.deliveriesAddresses);
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
        [Route("getDeliveriesAddress")]
        public async Task<IActionResult> GetDeliveriesAddress([FromQuery] int id)
        {
            var deliveriesAddress = await _mediator.Send(new GetDeliveriesAddressesQuery { IdDeliveriesAddresses = id });
            if (deliveriesAddress == null)
            {
                return NotFound();
            }

            return Ok(deliveriesAddress);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createDeliveriesAddress")]
        public async Task<IActionResult> CreateDeliveriesAddress([FromBody] CreateDeliveriesAddressesCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response.IdDeliveriesAddresses);
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
        [Route("deleteDeliveriesAddress")]
        public async Task<IActionResult> DeleteDeliveriesAddress([FromBody] DeleteDeliveriesAddressesCommand command)
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
