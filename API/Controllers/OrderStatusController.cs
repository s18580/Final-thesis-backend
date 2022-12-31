using Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand;
using Application.Functions.OrderStatus.Commands.DeleteOrderStatusCommand;
using Application.Functions.OrderStatus.Commands.UpdateOrderStatusCommand;
using Application.Functions.OrderStatus.Queries.GetOrderStatusListQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderStatusController : ControllerBase
    {
        private IMediator _mediator;

        public OrderStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getOrderStatuses")]
        public async Task<IActionResult> GetOrderStatuses()
        {
            var orderStatuses = await _mediator.Send(new GetOrderStatusListQuery());
            return Ok(orderStatuses);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createOrderStatus")]
        public async Task<IActionResult> CreateOrderStatus([FromBody] CreateOrderStatusCommand command)
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
        [Route("updateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusCommand command)
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
        [Route("deleteOrderStatus")]
        public async Task<IActionResult> DeleteOrderStatus([FromBody] DeleteOrderStatusCommand command)
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
