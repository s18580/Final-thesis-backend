using Application.Functions.Supply.Commands.CreateSupplyCommand;
using Application.Functions.Supply.Commands.DeleteSupplyCommand;
using Application.Functions.Supply.Commands.UpdateSupplyCommand;
using Application.Functions.Supply.Queries.GetSupplyListQuery;
using Application.Functions.Supply.Queries.GetSupplyQuery;
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
    public class SupplyController : ControllerBase
    {
        private IMediator _mediator;

        public SupplyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSupplies")]
        public async Task<IActionResult> GetSupplies()
        {
            var supplies = await _mediator.Send(new GetSupplyListQuery());
            return Ok(supplies);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSupply")]
        public async Task<IActionResult> GetSupply([FromQuery] int id)
        {
            var supply = await _mediator.Send(new GetSupplyQuery { IdSupply = id });
            if (supply == null)
            {
                return NotFound();
            }

            return Ok(supply);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createSupply")]
        public async Task<IActionResult> CreateSupply([FromBody] CreateSupplyCommand command)
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
        [Route("updateSupply")]
        public async Task<IActionResult> UpdateSupply([FromBody] UpdateSupplyCommand command)
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
        [Route("deleteSupply")]
        public async Task<IActionResult> DeleteSupply([FromBody] DeleteSupplyCommand command)
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
