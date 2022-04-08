using Application.Functions.Worksites.Commands.CreateWorksite;
using Application.Functions.Worksites.Commands.DeleteWorksite;
using Application.Functions.Worksites.Commands.UpdateWorksite;
using Application.Functions.Worksites.Queries.GetWorksite;
using Application.Functions.Worksites.Queries.GetWorksitesList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryDataController : ControllerBase
    {
        private IMediator _mediator;

        public DictionaryDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Worksite
        [HttpGet]
        [Route("getWorksites")]
        public async Task<IActionResult> GetWorksites()
        {
            var worksites = await _mediator.Send(new GetWorksitesListQuery());
            return Ok(worksites);
        }

        [HttpGet]
        [Route("getWorksite")]
        public async Task<IActionResult> GetWorksite([FromBody] GetWorksiteQuery query)
        {
            var worksite = await _mediator.Send(query);
            return Ok(worksite);
        }

        [HttpPost]
        [Route("createWorksite")]
        public async Task<IActionResult> CreateWorksite([FromBody] CreateWorksiteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("updateWorksite")]
        public async Task<IActionResult> UpdateWorksite([FromBody] UpdateWorksiteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteWorksite")]
        public async Task<IActionResult> DeleteWorksite([FromBody] DeleteWorksiteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok();
        }
        #endregion
    }
}
