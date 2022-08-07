using Application.Functions.File.Commands.CreateFileCommand;
using Application.Functions.File.Commands.DeleteFileCommand;
using Application.Functions.File.Commands.UpdateFileCommand;
using Application.Functions.File.Queries.GetFileListByOrderItemQuery;
using Application.Functions.File.Queries.GetFileListByOrderQuery;
using Application.Functions.File.Queries.GetFileListByValuationQuery;
using Application.Functions.File.Queries.GetFileQuery;
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
    public class FileController : ControllerBase
    {
        private IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getFilesByValuation")]
        public async Task<IActionResult> GetFilesByValuation([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetFileListByValuationQuery { IdValuation = id });
            if (response.Success)
            {
                return Ok(response.files);
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
        [Route("getFilesByOrderItem")]
        public async Task<IActionResult> GetFilesByOrderItem([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetFileListByOrderItemQuery { IdOrderItem = id });
            if (response.Success)
            {
                return Ok(response.files);
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
        [Route("getFilesByOrder")]
        public async Task<IActionResult> GetFilesByOrder([FromQuery] int id)
        {
            var files = await _mediator.Send(new GetFileListByOrderQuery { IdOrder = id });
            return Ok(files);

            var response = await _mediator.Send(new GetFileListByOrderQuery { IdOrder = id });
            if (response.Success)
            {
                return Ok(response.files);
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
        [Route("getFile")]
        public async Task<IActionResult> GetFile([FromQuery] int id)
        {
            var file = await _mediator.Send(new GetFileQuery { IdFile = id });
            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createFile")]
        public async Task<IActionResult> CreateFile([FromBody] CreateFileCommand command)
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

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("updateFile")]
        public async Task<IActionResult> UpdateFile([FromBody] UpdateFileCommand command)
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

        [HttpDelete, Authorize(Roles = "Basic")]
        [Route("deleteFile")]
        public async Task<IActionResult> DeleteFile([FromBody] DeleteFileCommand command)
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
