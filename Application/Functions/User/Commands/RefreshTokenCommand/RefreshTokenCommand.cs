using MediatR;

namespace Application.Functions.User.Commands.RefreshTokenCommand
{
    public class RefreshTokenCommand : IRequest<RefreshTokenResponse>
    {
        public string userEmail { get; set; }
        public string refreshToken { get; set; }
    }
}
