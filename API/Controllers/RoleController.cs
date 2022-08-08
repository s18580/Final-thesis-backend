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
    }
}
