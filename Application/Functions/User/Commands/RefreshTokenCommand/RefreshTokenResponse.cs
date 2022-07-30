using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.User.Commands.RefreshTokenCommand
{
    public class RefreshTokenResponse : BaseResponse
    {
        public string token { get; set; }
        public RefreshToken refreshToken { get; set; }

        public RefreshTokenResponse(string token, RefreshToken refreshToken) : base()
        {
            this.token = token;
            this.refreshToken = refreshToken;
        }

        public RefreshTokenResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public RefreshTokenResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
