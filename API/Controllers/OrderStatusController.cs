using Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand;
using Application.Functions.OrderStatus.Commands.DeleteOrderStatusCommand;
using Application.Functions.OrderStatus.Commands.UpdateOrderStatusCommand;
using Application.Functions.OrderStatus.Queries.GetOrderStatusListQuery;
using Application.Functions.OrderStatus.Queries.GetOrderStatusQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private IMediator _mediator;

        public OrderStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getOrderStatuses")]
        public async Task<IActionResult> GetOrderStatuses()
        {
            var orderStatuses = await _mediator.Send(new GetOrderStatusListQuery());
            return Ok(orderStatuses);
        }

        [HttpGet]
        [Route("getOrderStatus")]
        public async Task<IActionResult> GetOrderStatus([FromQuery] int id)
        {
            var orderStatus = await _mediator.Send(new GetOrderStatusQuery { IdOrderStatus = id });
            if (orderStatus == null)
            {
                return NotFound();
            }

            return Ok(orderStatus);
        }

        [HttpPost]
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

        [HttpPost]
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

        [HttpDelete]
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
