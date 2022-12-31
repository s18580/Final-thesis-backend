using Application.Functions.Address.Commands.CreateAddressCommand;
using Application.Functions.Address.Commands.DisableAddressCommand;
using Application.Functions.Address.Commands.UpdateAddressCommand;
using Application.Functions.Address.Queries.GetAddressListByCustomerIdQuery;
using Application.Functions.Address.Queries.GetAddressListBySupplierIdQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getAddressesByCustomer")]
        public async Task<IActionResult> GetAddressesByCustomer([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetAddressListByCustomerIdQuery { IdCustomer = id });
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

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getAddressesBySupplier")]
        public async Task<IActionResult> GetAddressesBySupplier([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetAddressListBySupplierIdQuery { IdSupplier = id });
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

        [HttpPost, Authorize(Roles = "Basic")]
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

        [HttpPost, Authorize(Roles = "Basic")]
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

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("disableAddress")]
        public async Task<IActionResult> DisableAddress([FromBody] DisableAddressCommand command)
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
