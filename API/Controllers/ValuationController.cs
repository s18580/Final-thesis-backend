using Application.Functions.Valuation.Commands.CreateValuationCommand;
using Application.Functions.Valuation.Commands.DeleteValuationCommand;
using Application.Functions.Valuation.Commands.UpdateValuationCommand;
using Application.Functions.Valuation.Queries.GetValuationListByOrderItemQuery;
using Application.Functions.Valuation.Queries.GetValuationListByWorkerQuery;
using Application.Functions.Valuation.Queries.GetValuationQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuationController : ControllerBase
    {
        private IMediator _mediator;

        public ValuationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
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

        [HttpGet]
        [Route("getValuationsByWorker")]
        public async Task<IActionResult> GetValuationsByWorker([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetValuationListByWorkerQuery { IdWorker = id });
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

        [HttpGet]
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

        [HttpPost]
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

        [HttpPost]
        [Route("updateValuation")]
        public async Task<IActionResult> UpdateValuation([FromBody] UpdateValuationCommand command)
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
        [Route("deleteValuation")]
        public async Task<IActionResult> DeleteValuation([FromBody] DeleteValuationCommand command)
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
