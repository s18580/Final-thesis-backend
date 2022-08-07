using Application.Functions.PriceList.Commands.CreatePriceListCommand;
using Application.Functions.PriceList.Commands.DeletePriceListCommand;
using Application.Functions.PriceList.Commands.UpdatePriceListCommand;
using Application.Functions.PriceList.Queries.GetPriceListListQuery;
using Application.Functions.PriceList.Queries.GetPriceListQuery;
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
    public class PriceListController : ControllerBase
    {
        private IMediator _mediator;

        public PriceListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getPriceLists")]
        public async Task<IActionResult> GetPriceLists()
        {
            var priceLists = await _mediator.Send(new GetPriceListListQuery());
            return Ok(priceLists);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getPriceList")]
        public async Task<IActionResult> GetPriceList([FromQuery] int id)
        {
            var priceList = await _mediator.Send(new GetPriceListQuery { IdPriceList = id });
            if (priceList == null)
            {
                return NotFound();
            }

            return Ok(priceList);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createPriceList")]
        public async Task<IActionResult> CreatePriceList([FromBody] CreatePriceListCommand command)
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
        [Route("updatePriceList")]
        public async Task<IActionResult> UpdatePriceList([FromBody] UpdatePriceListCommand command)
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
        [Route("deletePriceList")]
        public async Task<IActionResult> DeletePriceList([FromBody] DeletePriceListCommand command)
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
