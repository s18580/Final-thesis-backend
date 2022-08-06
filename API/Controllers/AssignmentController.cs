using Application.Functions.Assignment.Commands.CreateAssignmentCommand;
using Application.Functions.Assignment.Commands.DeleteAssignmentCommand;
using Application.Functions.Assignment.Commands.UpdateAssignmentCommand;
using Application.Functions.Assignment.Queries.GetAssignmentListByOrderQuery;
using Application.Functions.Assignment.Queries.GetAssignmentListByWorkerQuery;
using Application.Functions.Assignment.Queries.GetAssignmentQuery;
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
    public class AssignmentController : ControllerBase
    {
        private IMediator _mediator;

        public AssignmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getAssignmentsByWorker")]
        public async Task<IActionResult> GetAssignmentsByWorker([FromQuery] int workerId)
        {
            var response = await _mediator.Send(new GetAssignmentListByWorkerQuery { IdWorker = workerId });
            if (response.Success)
            {
                return Ok(response.assignments);
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
        [Route("getAssignmentsByOrder")]
        public async Task<IActionResult> GetAssignmentsByOrder([FromQuery] int orderId)
        {
            var response = await _mediator.Send(new GetAssignmentListByOrderQuery { IdOrder = orderId });
            if (response.Success)
            {
                return Ok(response.assignments);
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
        [Route("getAssignment")]
        public async Task<IActionResult> GetAssignment([FromQuery] int orderId, int workerId)
        {
            var assignment = await _mediator.Send(new GetAssignmentQuery { IdOrder = orderId, IdWorker = workerId });
            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createAssignment")]
        public async Task<IActionResult> CreateAssignment([FromBody] CreateAssignmentCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok( new 
                { 
                    IdWorker = response.IdWorker,
                    IdOrder = response.IdOrder
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
        
        [HttpPost, Authorize(Roles = "Basic")]
        [Route("updateAssignment")]
        public async Task<IActionResult> UpdateAssignment([FromBody] UpdateAssignmentCommand command)
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

        [HttpDelete, Authorize(Roles = "Basic")]
        [Route("deleteAssignment")]
        public async Task<IActionResult> DeleteAssignment([FromBody] DeleteAssignmentCommand command)
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
