using Application.Functions.Roles.Commands.CreateRole;
using Application.Functions.Roles.Commands.DeleteRole;
using Application.Functions.Roles.Commands.UpdateRole;
using Application.Functions.Roles.Queries.GetRole;
using Application.Functions.Roles.Queries.GetRolesList;
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
    public class RoleController : ControllerBase
    {
        private IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _mediator.Send(new GetRolesListQuery());
            return Ok(roles);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getRole")]
        public async Task<IActionResult> GetRole([FromQuery] int id)
        {
            var role = await _mediator.Send(new GetRoleQuery { Id = id });
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
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
        [Route("updateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
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
        [Route("deleteRole")]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleCommand command)
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
