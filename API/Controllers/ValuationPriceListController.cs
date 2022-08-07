using Application.Functions.ValuationPriceList.Commands.CreateValuationPriceListCommand;
using Application.Functions.ValuationPriceList.Commands.DeleteValuationPriceListCommand;
using Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByPriceListQuery;
using Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByValuationQuery;
using Application.Functions.ValuationPriceList.Queries.GetValuationPriceListQuery;
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
    public class ValuationPriceListController : ControllerBase
    {
        private IMediator _mediator;

        public ValuationPriceListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getValuationPriceListByValuation")]
        public async Task<IActionResult> GetValuationPriceListByValuation([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetValuationPriceListListByValuationQuery { IdValuation = id });
            if (response.Success)
            {
                return Ok(response.valuationPriceLists);
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
        [Route("getValuationPriceListByPriceList")]
        public async Task<IActionResult> GetValuationPriceListByPriceList([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetValuationPriceListListByPriceListQuery { IdPriceList = id });
            if (response.Success)
            {
                return Ok(response.valuationPriceLists);
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
        [Route("getValuationPriceList")]
        public async Task<IActionResult> GetValuationPriceList([FromQuery] int priceListId, int valuationId)
        {
            var valuationPriceList = await _mediator.Send(new GetValuationPriceListQuery { IdPriceList = priceListId, IdValuation = valuationId });
            if (valuationPriceList == null)
            {
                return NotFound();
            }

            return Ok(valuationPriceList);
        }

        [HttpPost, Authorize(Roles = "Office")]
        [Route("createValuationPriceList")]
        public async Task<IActionResult> CreateValuationPriceList([FromBody] CreateValuationPriceListCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(new
                {
                    IdValuation = response.IdValuation,
                    IdPriceList = response.IdPriceList
                });
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

        [HttpDelete, Authorize(Roles = "Office")]
        [Route("deleteValuationPriceList")]
        public async Task<IActionResult> DeleteValuationPriceList([FromBody] DeleteValuationPriceListCommand command)
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
