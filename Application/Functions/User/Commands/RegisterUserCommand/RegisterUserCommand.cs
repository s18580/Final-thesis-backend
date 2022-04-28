using MediatR;

namespace Application.Functions.User.Commands.RegisterUserCommand
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public AnonymousUserDTO anonymousUserData { get; set; }
    }
}
