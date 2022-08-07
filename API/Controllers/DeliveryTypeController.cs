using Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand;
using Application.Functions.DeliveryType.Commands.DeleteDeliveryTypeCommand;
using Application.Functions.DeliveryType.Commands.UpdateDeliveryTypeCommand;
using Application.Functions.DeliveryType.Queries.GetDeliveryTypeListQuery;
using Application.Functions.DeliveryType.Queries.GetDeliveryTypeQuery;
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
    public class DeliveryTypeController : ControllerBase
    {
        private IMediator _mediator;

        public DeliveryTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getDeliveryTypes")]
        public async Task<IActionResult> GetDeliveryTypes()
        {
            var deliveryTypes = await _mediator.Send(new GetDeliveryTypeListQuery());
            return Ok(deliveryTypes);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getDeliveryType")]
        public async Task<IActionResult> GetDeliveryType([FromQuery] int id)
        {
            var deliveryType = await _mediator.Send(new GetDeliveryTypeQuery { IdDeliveryType = id });
            if (deliveryType == null)
            {
                return NotFound();
            }

            return Ok(deliveryType);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createDeliveryType")]
        public async Task<IActionResult> CreateDeliveryType([FromBody] CreateDeliveryTypeCommand command)
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

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("updateDeliveryType")]
        public async Task<IActionResult> UpdateDeliveryType([FromBody] UpdateDeliveryTypeCommand command)
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

        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("deleteDeliveryType")]
        public async Task<IActionResult> DeleteDeliveryType([FromBody] DeleteDeliveryTypeCommand command)
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
