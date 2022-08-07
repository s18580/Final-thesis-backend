using Application.Functions.Color.Commands.CreateColorCommand;
using Application.Functions.Color.Commands.DeleteColorCommand;
using Application.Functions.Color.Commands.UpdateColorCommand;
using Application.Functions.Color.Queries.GetColorListByOrderItemQuery;
using Application.Functions.Color.Queries.GetColorListByValuationQuery;
using Application.Functions.Color.Queries.GetColorQuery;
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
    public class ColorController : ControllerBase
    {
        private IMediator _mediator;

        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getColorsByOrderItem")]
        public async Task<IActionResult> GetColorsByOrderItem([FromQuery] int id)
        {
            var colors = await _mediator.Send(new GetColorListByOrderItemQuery { IdOrderItem = id });
            return Ok(colors.colors);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getColorsByValuation")]
        public async Task<IActionResult> GetColorsByValuation([FromQuery] int id)
        {
            var colors = await _mediator.Send(new GetColorListByValuationQuery { IdValuation = id });
            return Ok(colors.colors);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getColor")]
        public async Task<IActionResult> GetColor([FromQuery] int id)
        {
            var color = await _mediator.Send(new GetColorQuery { IdColor = id });
            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createColor")]
        public async Task<IActionResult> CreateColor([FromBody] CreateColorCommand command)
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
        [Route("updateColor")]
        public async Task<IActionResult> UpdateColor([FromBody] UpdateColorCommand command)
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
        [Route("deleteColor")]
        public async Task<IActionResult> DeleteColor([FromBody] DeleteColorCommand command)
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
