using Application.Functions.Valuation.Commands.CreateValuationCommand;
using Application.Functions.Valuation.Queries.GetSearchValuationListQuery;
using Application.Functions.Valuation.Queries.GetValuationListByOrderItemQuery;
using Application.Functions.Valuation.Queries.GetValuationListWithoutOrderItemQuery;
using Application.Functions.Valuation.Queries.GetValuationQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuationController : ControllerBase
    {
        private IMediator _mediator;

        public ValuationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getValuationsByOrderItem")]
        public async Task<IActionResult> GetValuationsByOrderItem([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetValuationListByOrderItemQuery { IdOrderItem = id });
            if (response.Success)
            {
                return Ok(response.valuations);
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
        [Route("getValuationsWithoutOrderItem")]
        public async Task<IActionResult> GetValuationsWithoutOrderItem()
        {
            var valuations = await _mediator.Send(new GetValuationListWithoutOrderItemQuery());
            return Ok(valuations);
        }

        [HttpGet, Authorize(Roles = "Office")]
        [Route("getValuation")]
        public async Task<IActionResult> GetValuation([FromQuery] int id)
        {
            var valuation = await _mediator.Send(new GetValuationQuery { IdValuation = id });
            if (valuation == null)
            {
                return NotFound();
            }

            return Ok(valuation);
        }

        [HttpGet, Authorize(Roles = "Office")]
        [Route("getSearchValuations")]
        public async Task<IActionResult> GetSearchValuations(string valuationName, string author, string paper, string color, string serviceName, string bindingType, string orderName, string orderItemType, string orderItem, string creationDate)
        {
            var valuations = await _mediator.Send(new GetSearchValuationListQuery() { ValuationName = valuationName, Author = author, Paper = paper, Color = color, ServiceName = serviceName, BindingType = bindingType, OrderName = orderName, OrderItemType = orderItemType, OrderItem = orderItem, CreationDate = creationDate });
            return Ok(valuations);
        }

        [HttpPost, Authorize(Roles = "Office")]
        [Route("createValuation")]
        public async Task<IActionResult> CreateValuation([FromBody] CreateValuationCommand command)
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
    }
}
