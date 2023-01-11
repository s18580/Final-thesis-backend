using Application.Functions.BindingType.Commands.CreateBindingTypeCommand;
using Application.Functions.BindingType.Commands.DeleteBindingTypeCommand;
using Application.Functions.BindingType.Commands.UpdateBindingTypeCommand;
using Application.Functions.BindingType.Queries.GetBindingTypeListQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BindingTypeController : ControllerBase
    {
        private IMediator _mediator;

        public BindingTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic,Admin")]
        [Route("getBindingTypes")]
        public async Task<IActionResult> GetBindingTypes()
        {
            var bindingTypes = await _mediator.Send(new GetBindingTypeListQuery());
            return Ok(bindingTypes);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createBindingType")]
        public async Task<IActionResult> CreateBindingType([FromBody] CreateBindingTypeCommand command)
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
        [Route("updateBindingType")]
        public async Task<IActionResult> UpdateBindingType([FromBody] UpdateBindingTypeCommand command)
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
        [Route("deleteBindingType")]
        public async Task<IActionResult> DeleteBindingType([FromBody] DeleteBindingTypeCommand command)
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
