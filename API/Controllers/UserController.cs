using Application.Functions.User;
using Application.Functions.User.Commands.RefreshTokenCommand;
using Application.Functions.User.Commands.RegisterUserCommand;
using Application.Functions.User.Queries.LoginUserQuery;
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
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
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
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserQuery query)
        {
            var response = await _mediator.Send(query);
            if (response.Success)
            {
                SetRefreshToken(response.refreshToken);
                return Ok(response.token);
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
        [Route("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] string userEmail)
        {
            var refreshToken = Request.Cookies["printingRefreshToken"];

            var response = await _mediator.Send(new RefreshTokenCommand { userEmail = userEmail, refreshToken = refreshToken });
            if (response.Success)
            {
                SetRefreshToken(response.refreshToken);
                return Ok(response.token);
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

        private void SetRefreshToken(RefreshToken refreshTokenToSet)
        {
            var coockieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshTokenToSet.Expires,
            };

            Response.Cookies.Append("printingRefreshToken", refreshTokenToSet.Token, coockieOptions);
        }
    }
}
