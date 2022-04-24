using Application.Functions.PriceList.Commands.CreatePriceListCommand;
using Application.Functions.PriceList.Commands.DeletePriceListCommand;
using Application.Functions.PriceList.Commands.UpdatePriceListCommand;
using Application.Functions.PriceList.Queries.GetPriceListQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        private IMediator _mediator;

        public PriceListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
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

        [HttpPost]
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

        [HttpPost]
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

        [HttpDelete]
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
