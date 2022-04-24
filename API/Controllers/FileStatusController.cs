using Application.Functions.FileStatus.Commands.CreateFileStatusCommand;
using Application.Functions.FileStatus.Commands.DeleteFileStatusCommand;
using Application.Functions.FileStatus.Commands.UpdateFileStatusCommand;
using Application.Functions.FileStatus.Queries.GetFileStatusListQuery;
using Application.Functions.FileStatus.Queries.GetFileStatusQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStatusController : ControllerBase
    {
        private IMediator _mediator;

        public FileStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getFileStatuses")]
        public async Task<IActionResult> GetFileStatuses()
        {
            var fileStatuses = await _mediator.Send(new GetFileStatusListQuery());
            return Ok(fileStatuses);
        }

        [HttpGet]
        [Route("getFileStatus")]
        public async Task<IActionResult> GetFileStatus([FromQuery] int id)
        {
            var fileStatus = await _mediator.Send(new GetFileStatusQuery { IdFileStatus = id });
            if (fileStatus == null)
            {
                return NotFound();
            }

            return Ok(fileStatus);
        }

        [HttpPost]
        [Route("createFileStatus")]
        public async Task<IActionResult> CreateFileStatus([FromBody] CreateFileStatusCommand command)
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
        [Route("updateFileStatus")]
        public async Task<IActionResult> UpdateFileStatus([FromBody] UpdateFileStatusCommand command)
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
        [Route("deleteFileStatus")]
        public async Task<IActionResult> DeleteFileStatus([FromBody] DeleteFileStatusCommand command)
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
