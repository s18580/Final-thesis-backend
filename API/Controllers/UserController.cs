using Application.Functions.User;
using Application.Functions.User.Commands.RegisterUserCommand;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] AnonymousUserDTO data)
        {
            var response = await _mediator.Send(new RegisterUserCommand { anonymousUserData = data });
            if (response.Success)
            {
                return Ok(response.loggedUserData);
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
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] AnonymousUserDTO data)
        {
            var response = await _mediator.Send(new RegisterUserCommand { anonymousUserData = data });
            if (response.Success)
            {
                return Ok(response.loggedUserData);
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
