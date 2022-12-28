using Application.Functions.Representative.Commands.CreateRepresentativeCommand;
using Application.Functions.Representative.Commands.DisableRepresentativeCommand;
using Application.Functions.Representative.Commands.UpdateRepresentativeCommand;
using Application.Functions.Representative.Queries.GetCustomerActiveRepresentativesListQuery;
using Application.Functions.Representative.Queries.GetCustomerRepresentativesListQuery;
using Application.Functions.Representative.Queries.GetRepresentativeListByCustomerQuery;
using Application.Functions.Representative.Queries.GetRepresentativeListBySupplierQuery;
using Application.Functions.Representative.Queries.GetRepresentativeListQuery;
using Application.Functions.Representative.Queries.GetRepresentativeQuery;
using Application.Functions.Representative.Queries.GetSearchRepresentativeListQuery;
using Application.Functions.Representative.Queries.GetSupplierActiveRepresentativesListQuery;
using Application.Functions.Representative.Queries.GetSupplierRepresentativesListQuery;
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
    public class RepresentativeController : ControllerBase
    {
        private IMediator _mediator;

        public RepresentativeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getRepresentatives")]
        public async Task<IActionResult> GetRepresentatives()
        {
            var representatives = await _mediator.Send(new GetRepresentativeListQuery());
            return Ok(representatives);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSearchRepresentatives")]
        public async Task<IActionResult> GetSearchRepresentatives([FromQuery] string name, string lastName, string email, string phone, string customer, string supplier, bool isDisabled)
        {
            var representatives = await _mediator.Send(new GetSearchRepresentativeListQuery() { Name = name, LastName = lastName, Email = email, Phone = phone, Customer = customer, Supplier = supplier, IsDisabled = isDisabled });
            return Ok(representatives);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getCustomerRepresentatives")]
        public async Task<IActionResult> GetCustomerRepresentatives()
        {
            var representatives = await _mediator.Send(new GetCustomerRepresentativesListQuery());
            return Ok(representatives);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getCustomerActiveRepresentatives")]
        public async Task<IActionResult> GetCustomerActiveRepresentatives(int id)
        {
            var representatives = await _mediator.Send(new GetCustomerActiveRepresentativesListQuery { Id = id });
            return Ok(representatives);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSupplierRepresentatives")]
        public async Task<IActionResult> GetSupplierRepresentatives()
        {
            var representatives = await _mediator.Send(new GetSupplierRepresentativesListQuery());
            return Ok(representatives);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSupplierActiveRepresentatives")]
        public async Task<IActionResult> GetSupplierActiveRepresentatives(int id)
        {
            var representatives = await _mediator.Send(new GetSupplierActiveRepresentativesListQuery { Id = id });
            return Ok(representatives);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getRepresentativesByCustomer")]
        public async Task<IActionResult> GetRepresentativesByCustomer([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetRepresentativeListByCustomerQuery { CustomerId = id });
            if (response.Success)
            {
                return Ok(response.Representatives);
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
        [Route("getRepresentativesBySupplier")]
        public async Task<IActionResult> GetRepresentativesBySupplier([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetRepresentativeListBySupplierQuery { SupplierId = id });
            if (response.Success)
            {
                return Ok(response.Representatives);
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
        [Route("getRepresentative")]
        public async Task<IActionResult> GetRepresentative([FromQuery] int id)
        {
            var representative = await _mediator.Send(new GetRepresentativeQuery { IdRepresentative = id });
            if (representative == null)
            {
                return NotFound();
            }

            return Ok(representative);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createRepresentative")]
        public async Task<IActionResult> CreateRepresentative([FromBody] CreateRepresentativeCommand command)
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
        [Route("updateRepresentative")]
        public async Task<IActionResult> UpdateRepresentative([FromBody] UpdateRepresentativeCommand command)
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
        [Route("disableRepresentative")]
        public async Task<IActionResult> DisableRepresentative([FromBody] DisableRepresentativeCommand command)
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
