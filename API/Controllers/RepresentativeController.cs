using Application.Functions.Representative.Commands.CreateRepresentativeCommand;
using Application.Functions.Representative.Commands.DeleteRepresentativeCommand;
using Application.Functions.Representative.Commands.UpdateRepresentativeCommand;
using Application.Functions.Representative.Queries.GetRepresentativeListQuery;
using Application.Functions.Representative.Queries.GetRepresentativeQuery;
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

        [HttpDelete, Authorize(Roles = "Basic")]
        [Route("deleteRepresentative")]
        public async Task<IActionResult> DeleteRepresentative([FromBody] DeleteRepresentativeCommand command)
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
