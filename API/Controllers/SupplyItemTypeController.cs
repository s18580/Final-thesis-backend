using Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand;
using Application.Functions.SupplyItemType.Commands.DeleteSupplyItemTypeCommand;
using Application.Functions.SupplyItemType.Commands.UpdateSupplyItemTypeCommand;
using Application.Functions.SupplyItemType.Queries.GetSupplyItemTypeListQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplyItemTypeController : ControllerBase
    {
        private IMediator _mediator;

        public SupplyItemTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic,Admin")]
        [Route("getSupplyItemsTypes")]
        public async Task<IActionResult> GetSupplyItemsTypes()
        {
            var supplyItemsType = await _mediator.Send(new GetSupplyItemTypeListQuery());
            return Ok(supplyItemsType);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createSupplyItemsType")]
        public async Task<IActionResult> CreateSupplyItemsType([FromBody] CreateSupplyItemTypeCommand command)
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
        [Route("updateSupplyItemsType")]
        public async Task<IActionResult> UpdateSupplyItemsType([FromBody] UpdateSupplyItemTypeCommand command)
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
        [Route("deleteSupplyItemsType")]
        public async Task<IActionResult> DeleteSupplyItemsType([FromBody] DeleteSupplyItemTypeCommand command)
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
