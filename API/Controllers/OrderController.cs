using Application.Functions.Order.Commands.CreateOrderCommand;
using Application.Functions.Order.Commands.DeleteOrderCommand;
using Application.Functions.Order.Commands.UpdateOrderCommand;
using Application.Functions.Order.Queries.GetOrderListByWorkerQuery;
using Application.Functions.Order.Queries.GetOrderListQuery;
using Application.Functions.Order.Queries.GetOrderQuery;
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
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrderListQuery());
            return Ok(orders);
        }

        [HttpGet, Authorize(Roles = "Basic")]
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

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getOrdersByWorker")]
        public async Task<IActionResult> GetOrdersByWorker([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetOrderListByWorkerQuery() { IdWorker = id });
            if (response.Success)
            {
                return Ok(response.Orders);
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
        [Route("createOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
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

        [HttpDelete, Authorize(Roles = "Basic")]
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
