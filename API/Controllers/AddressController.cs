using Application.Functions.Address.Commands.CreateAddressCommand;
using Application.Functions.Address.Commands.DeleteAddressCommand;
using Application.Functions.Address.Commands.UpdateAddressCommand;
using Application.Functions.Address.Queries.GetAddressListByOwnerIdQuery;
using Application.Functions.Address.Queries.GetAddressListQuery;
using Application.Functions.Address.Queries.GetAddressQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAddresses")]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _mediator.Send(new GetAddressListQuery());
            return Ok(addresses);
        }

        [HttpGet]
        [Route("getAddressesByOwner")]
        public async Task<IActionResult> GetAddressesByOwner([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetAddressListByOwnerIdQuery { IdOwner = id });
            if (response.Success)
            {
                return Ok(response.address);
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

        [HttpGet]
        [Route("getAddress")]
        public async Task<IActionResult> GetAddress([FromQuery] int id)
        {
            var address = await _mediator.Send(new GetAddressQuery { IdAddress = id });
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        [Route("createAddress")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command)
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

        [HttpPost]
        [Route("updateAddress")]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand command)
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
        [Route("deleteAddress")]
        public async Task<IActionResult> DeleteAddress([FromBody] DeleteAddressCommand command)
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
