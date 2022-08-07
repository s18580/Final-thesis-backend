using Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand;
using Application.Functions.RoleAssignment.Commands.DeleteRoleAssignmentCommand;
using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentListByRoleIdQuery;
using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentQuery;
using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListQuery;
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
    public class RoleAssignmentController : ControllerBase
    {
        private IMediator _mediator;

        public RoleAssignmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getRoleAssignmentsWorker")]
        public async Task<IActionResult> GetRoleAssignmentsByWorker([FromQuery] int workerId)
        {
            var response = await _mediator.Send(new GetRoleAssignmentListByWorkerIdQuery { IdWorker = workerId });
            if (response.Success)
            {
                return Ok(response.roleAssignments);
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
        [Route("getRoleAssignmentsRole")]
        public async Task<IActionResult> GetRoleAssignmentsByRole([FromQuery] int roleId)
        {
            var response = await _mediator.Send(new GetRoleAssignmentListByRoleIdQuery { IdRole = roleId });
            if (response.Success)
            {
                return Ok(response.roleAssignments);
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
        [Route("getRoleAssignment")]
        public async Task<IActionResult> GetRoleAssignment([FromQuery] int roleId, int workerId)
        {
            var roleAssignment = await _mediator.Send(new GetRoleAssignmentQuery { IdRole = roleId, IdWorker = workerId });
            if (roleAssignment == null)
            {
                return NotFound();
            }

            return Ok(roleAssignment);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("createRoleAssignment")]
        public async Task<IActionResult> CreateRoleAssignment([FromBody] CreateRoleAssignmentCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(new
                {
                    IdRole = response.IdRole,
                    IdWorker = response.IdWorker
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

        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("deleteRoleAssignment")]
        public async Task<IActionResult> DeleteRoleAssignment([FromBody] DeleteRoleAssignmentCommand command)
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
