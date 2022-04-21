using Application.Functions.OrderItem.Commands.CreateOrderItemCommand;
using Application.Functions.OrderItem.Commands.DeleteOrderItemCommand;
using Application.Functions.OrderItem.Commands.UpdateOrderItemCommand;
using Application.Functions.OrderItem.Queries.GetOrderItemListByOrderIdQuery;
using Application.Functions.OrderItem.Queries.GetOrderItemListQuery;
using Application.Functions.OrderItem.Queries.GetOrderItemQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getOrderItemsByOrder")]
        public async Task<IActionResult> GetOrderItemsByOrder([FromQuery] int id)
        {
            var orderItems = await _mediator.Send(new GetOrderItemListByOrderIdQuery { IdOrder = id});
            return Ok(orderItems);
        }

        [HttpGet]
        [Route("getOrderItems")]
        public async Task<IActionResult> GetOrderItems()
        {
            var orderItems = await _mediator.Send(new GetOrderItemListQuery());
            return Ok(orderItems);
        }

        [HttpGet]
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

        [HttpPost]
        [Route("createOrderItem")]
        public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemCommand command)
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

        [HttpDelete]
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
