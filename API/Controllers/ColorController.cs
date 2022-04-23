using Application.Functions.Color.Commands.CreateColorCommand;
using Application.Functions.Color.Commands.DeleteColorCommand;
using Application.Functions.Color.Commands.UpdateColorCommand;
using Application.Functions.Color.Queries.GetColorListByOrderItemQuery;
using Application.Functions.Color.Queries.GetColorListByValuationQuery;
using Application.Functions.Color.Queries.GetColorQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private IMediator _mediator;

        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getColorsByOrderItem")]
        public async Task<IActionResult> GetColorsByOrderItem([FromQuery] int id)
        {
            var colors = await _mediator.Send(new GetColorListByOrderItemQuery { IdOrderItem = id });
            return Ok(colors);
        }

        [HttpGet]
        [Route("getColorsByValuation")]
        public async Task<IActionResult> GetColorsByValuation([FromQuery] int id)
        {
            var colors = await _mediator.Send(new GetColorListByValuationQuery { IdValuation = id });
            return Ok(colors);
        }

        [HttpGet]
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

        [HttpPost]
        [Route("createColor")]
        public async Task<IActionResult> CreateColor([FromBody] CreateColorCommand command)
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

        [HttpDelete]
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
