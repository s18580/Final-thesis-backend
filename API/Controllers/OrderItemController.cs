using Application.Functions.OrderItem.Commands.CreateOrderItemCommand;
using Application.Functions.OrderItem.Commands.DeleteOrderItemCommand;
using Application.Functions.OrderItem.Commands.UpdateOrderItemCommand;
using Application.Functions.OrderItem.Queries.GetOrderItemListByOrderIdQuery;
using Application.Functions.OrderItem.Queries.GetOrderItemListQuery;
using Application.Functions.OrderItem.Queries.GetOrderItemQuery;
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
    public class OrderItemController : ControllerBase
    {
        private IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getOrderItemsByOrder")]
        public async Task<IActionResult> GetOrderItemsByOrder([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetOrderItemListByOrderIdQuery { IdOrder = id });
            if (response.Success)
            {
                return Ok(response.orderItems);
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
        [Route("getOrderItems")]
        public async Task<IActionResult> GetOrderItems()
        {
            var orderItems = await _mediator.Send(new GetOrderItemListQuery());
            return Ok(orderItems);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getOrderItem")]
        public async Task<IActionResult> GetOrderItem([FromQuery] int id)
        {
            var orderItem = await _mediator.Send(new GetOrderItemQuery { IdOrderItem = id });
            if (orderItem == null)
            {
                return NotFound();
            }

            return Ok(orderItem);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createOrderItem")]
        public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemCommand command)
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
        [Route("updateOrderItem")]
        public async Task<IActionResult> UpdateOrderItem([FromBody] UpdateOrderItemCommand command)
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
        [Route("deleteOrderItem")]
        public async Task<IActionResult> DeleteOrderItem([FromBody] DeleteOrderItemCommand command)
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
