using Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand;
using Application.Functions.RoleAssignment.Commands.DeleteRoleAssignmentCommand;
using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentListByRoleIdQuery;
using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentQuery;
using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignmentController : ControllerBase
    {
        private IMediator _mediator;

        public RoleAssignmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getRoleAssignmentsWorker")]
        public async Task<IActionResult> GetRoleAssignmentsByWorker()
        {
            var response = await _mediator.Send(new GetRoleAssignmentListByWorkerIdQuery());
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

        [HttpGet]
        [Route("getRoleAssignmentsRole")]
        public async Task<IActionResult> GetRoleAssignmentsByRole()
        {
            var response = await _mediator.Send(new GetRoleAssignmentListByRoleIdQuery());
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

        [HttpGet]
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

        [HttpPost]
        [Route("createRoleAssignment")]
        public async Task<IActionResult> CreateRoleAssignment([FromBody] CreateRoleAssignmentCommand command)
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

        [HttpDelete]
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
