using Application.Functions.OrderItemType.Commands.CreateOrderItemTypeCommand;
using Application.Functions.OrderItemType.Commands.DeleteOrderItemTypeCommand;
using Application.Functions.OrderItemType.Commands.UpdateOrderItemTypeCommand;
using Application.Functions.OrderItemType.Queries.GetOrderItemTypeListQuery;
using Application.Functions.OrderItemType.Queries.GetOrderItemTypeQuery;
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
    public class OrderItemTypeController : ControllerBase
    {
        private IMediator _mediator;

        public OrderItemTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getOrderItemsTypes")]
        public async Task<IActionResult> GetOrderItemsTypes()
        {
            var orderItemsType = await _mediator.Send(new GetOrderItemTypeListQuery());
            return Ok(orderItemsType);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getOrderItemsType")]
        public async Task<IActionResult> GetOrderItemsType([FromQuery] int id)
        {
            var orderItemType = await _mediator.Send(new GetOrderItemTypeQuery { IdOrderItemType = id });
            if (orderItemType == null)
            {
                return NotFound();
            }

            return Ok(orderItemType);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createOrderItemsType")]
        public async Task<IActionResult> CreateOrderItemsType([FromBody] CreateOrderItemTypeCommand command)
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
        [Route("updateOrderItemsType")]
        public async Task<IActionResult> UpdateOrderItemsType([FromBody] UpdateOrderItemTypeCommand command)
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
        [Route("deleteOrderItemsType")]
        public async Task<IActionResult> DeleteOrderItemsType([FromBody] DeleteOrderItemTypeCommand command)
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
