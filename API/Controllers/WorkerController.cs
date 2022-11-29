using Application.Functions.Workers.Commands.DisableWorker;
using Application.Functions.Workers.Commands.UpdateWorker;
using Application.Functions.Workers.Queries.GetAWSCreds;
using Application.Functions.Workers.Queries.GetSearchWorkers;
using Application.Functions.Workers.Queries.GetWorker;
using Application.Functions.Workers.Queries.GetWorkersList;
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
    public class WorkerController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IConfiguration _configuration;

        public WorkerController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getWorkers")]
        public async Task<IActionResult> GetWorkers()
        {
            var workers = await _mediator.Send(new GetWorkersListQuery());
            return Ok(workers);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSearchWorkers")]
        public async Task<IActionResult> GetSearchWorkers([FromQuery] string name, string lastName, string worksite)
        {
            var workers = await _mediator.Send(new GetSearchWorkers() { Name = name, LastName = lastName, WorksiteName = worksite });
            return Ok(workers);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getWorker")]
        public async Task<IActionResult> GetWorker([FromQuery] int id)
        {
            var worker = await _mediator.Send(new GetWorkerQuery { Id = id });
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getAWS")]
        public async Task<IActionResult> GetAWSCreds([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetAWSCreds { Id = id });
            if (response == null)
            {
                return NotFound();
            }
            response.Region = _configuration.GetSection("AwsRegion").Value;
            response.BucketName = _configuration.GetSection("AwsAlbumBucketName").Value;

            return Ok(response);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("updateWorker")]
        public async Task<IActionResult> UpdateWorker([FromBody] UpdateWorkerCommand command)
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

        [HttpPost, Authorize(Roles = "Admin")]
        [Route("disableWorker")]
        public async Task<IActionResult> DisableWorker([FromBody] DisableWorkerCommand command)
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
