using Application.Functions.FileType.Commands.CreateFileTypeCommand;
using Application.Functions.FileType.Commands.DeleteFileTypeCommand;
using Application.Functions.FileType.Commands.UpdateFileTypeCommand;
using Application.Functions.FileType.Queries.GetFileTypeListQuery;
using Application.Functions.FileType.Queries.GetFileTypeQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTypeController : ControllerBase
    {
        private IMediator _mediator;

        public FileTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getFileTypes")]
        public async Task<IActionResult> GetFileTypes()
        {
            var fileTypes = await _mediator.Send(new GetFileTypeListQuery());
            return Ok(fileTypes);
        }

        [HttpGet]
        [Route("getFileType")]
        public async Task<IActionResult> GetFileType([FromQuery] int id)
        {
            var fileType = await _mediator.Send(new GetFileTypeQuery { IdFileType = id });
            if (fileType == null)
            {
                return NotFound();
            }

            return Ok(fileType);
        }

        [HttpPost]
        [Route("createFileType")]
        public async Task<IActionResult> CreateFileType([FromBody] CreateFileTypeCommand command)
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
        [Route("updateFileType")]
        public async Task<IActionResult> UpdateFileType([FromBody] UpdateFileTypeCommand command)
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
        [Route("deleteFileType")]
        public async Task<IActionResult> DeleteFileType([FromBody] DeleteFileTypeCommand command)
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
