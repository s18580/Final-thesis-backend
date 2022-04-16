using Application.Functions.Order.Commands.CreateOrderCommand;
using Application.Functions.Order.Commands.DeleteOrderCommand;
using Application.Functions.Order.Commands.UpdateOrderCommand;
using Application.Functions.Order.Queries.GetOrderListQuery;
using Application.Functions.Order.Queries.GetOrderQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrderListQuery());
            return Ok(orders);
        }

        [HttpGet]
        [Route("getOrder")]
        public async Task<IActionResult> GetOrder([FromQuery] int id)
        {
            var order = await _mediator.Send(new GetOrderQuery { IdOrder = id });
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        [Route("createOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
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
        [Route("updateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
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
        [Route("deleteOrder")]
        public async Task<IActionResult> DeleteOrder([FromBody] DeleteOrderCommand command)
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
