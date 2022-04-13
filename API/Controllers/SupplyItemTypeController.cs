using Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand;
using Application.Functions.SupplyItemType.Commands.DeleteSupplyItemTypeCommand;
using Application.Functions.SupplyItemType.Commands.UpdateSupplyItemTypeCommand;
using Application.Functions.SupplyItemType.Queries.GetSupplyItemTypeListQuery;
using Application.Functions.SupplyItemType.Queries.GetSupplyItemTypeQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyItemTypeController : ControllerBase
    {
        private IMediator _mediator;

        public SupplyItemTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getSupplyItemsType")]
        public async Task<IActionResult> GetWorkers()
        {
            var supplyItemsType = await _mediator.Send(new GetSupplyItemTypeListQuery());
            return Ok(supplyItemsType);
        }

        [HttpGet]
        [Route("getSupplyItemsType")]
        public async Task<IActionResult> GetWorker([FromQuery] int id)
        {
            var supplyItemType = await _mediator.Send(new GetSupplyItemTypeQuery { IdSupplyItemType = id });
            if (supplyItemType == null)
            {
                return NotFound();
            }

            return Ok(supplyItemType);
        }

        [HttpPost]
        [Route("createSupplyItemsType")]
        public async Task<IActionResult> CreateWorker([FromBody] CreateSupplyItemTypeCommand command)
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
        [Route("updateSupplyItemsType")]
        public async Task<IActionResult> UpdateWorker([FromBody] UpdateSupplyItemTypeCommand command)
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
        [Route("deleteSupplyItemsType")]
        public async Task<IActionResult> DeleteWorker([FromBody] DeleteSupplyItemTypeCommand command)
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
