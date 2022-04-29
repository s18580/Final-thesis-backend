using MediatR;

namespace Application.Functions.User.Queries.LoginUserQuery
{
    public class LoginUserQuery : IRequest<LoginUserResponse>
    {
        public AnonymousUserDTO anonymousUserData { get; set; }
    }
}
