using Application.Functions.Worksites.Commands.CreateWorksite;
using Application.Functions.Worksites.Commands.DeleteWorksite;
using Application.Functions.Worksites.Commands.UpdateWorksite;
using Application.Functions.Worksites.Queries.GetWorksite;
using Application.Functions.Worksites.Queries.GetWorksitesList;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksiteController : ControllerBase
    {
        private IMediator _mediator;

        public WorksiteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getWorksites")]
        public async Task<IActionResult> GetWorksites()
        {
            var worksites = await _mediator.Send(new GetWorksitesListQuery());
            return Ok(worksites);
        }

        [HttpGet]
        [Route("getWorksite")]
        public async Task<IActionResult> GetWorksite([FromQuery] int id)
        {
            var worksite = await _mediator.Send(new GetWorksiteQuery { Id = id });
            if (worksite == null)
            {
                return NotFound();
            }

            return Ok(worksite);
        }

        [HttpPost]
        [Route("createWorksite")]
        public async Task<IActionResult> CreateWorksite([FromBody] CreateWorksiteCommand command)
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
        [Route("updateWorksite")]
        public async Task<IActionResult> UpdateWorksite([FromBody] UpdateWorksiteCommand command)
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
        [Route("deleteWorksite")]
        public async Task<IActionResult> DeleteWorksite([FromBody] DeleteWorksiteCommand command)
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
