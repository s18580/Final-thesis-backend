using Application.Functions.Paper.Commands.CreatePaperCommand;
using Application.Functions.Paper.Commands.DeletePaperCommand;
using Application.Functions.Paper.Commands.UpdatePaperCommand;
using Application.Functions.Paper.Queries.GetPaperListByOrderItemQuery;
using Application.Functions.Paper.Queries.GetPaperListByValuationQuery;
using Application.Functions.Paper.Queries.GetPaperQuery;
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
    public class PaperController : ControllerBase
    {
        private IMediator _mediator;

        public PaperController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getPapersByOrderItem")]
        public async Task<IActionResult> GetPapersByOrderItem([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetPaperListByOrderItemQuery { IdOrderItem = id });
            if (response.Success)
            {
                return Ok(response.papers);
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
        [Route("getPapersByValuation")]
        public async Task<IActionResult> GetPapersByValuation([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetPaperListByValuationQuery { IdValuation = id });
            if (response.Success)
            {
                return Ok(response.papers);
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
        [Route("getPaper")]
        public async Task<IActionResult> GetPaper([FromQuery] int id)
        {
            var paper = await _mediator.Send(new GetPaperQuery { IdPaper = id });
            if (paper == null)
            {
                return NotFound();
            }

            return Ok(paper);
        }

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createPaper")]
        public async Task<IActionResult> CreatePaper([FromBody] CreatePaperCommand command)
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
        [Route("updatePaper")]
        public async Task<IActionResult> UpdatePaper([FromBody] UpdatePaperCommand command)
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
        [Route("deletePaper")]
        public async Task<IActionResult> DeletePaper([FromBody] DeletePaperCommand command)
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
