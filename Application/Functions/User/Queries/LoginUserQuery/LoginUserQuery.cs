using MediatR;

namespace Application.Functions.User.Queries.LoginUserQuery
{
    public class LoginUserQuery : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
