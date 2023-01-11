using Application.Functions.Role.Queries.GetRolesListQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, Authorize(Roles = "Basic,Admin")]
        [Route("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _mediator.Send(new GetRolesListQuery());
            return Ok(roles);
        }
    }
}