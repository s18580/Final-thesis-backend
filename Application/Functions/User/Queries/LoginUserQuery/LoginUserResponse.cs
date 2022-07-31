using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.User.Queries.LoginUserQuery
{
    public class LoginUserResponse : BaseResponse
    {
        public string token { get; set; }
        public RefreshToken refreshToken { get; set; }

        public LoginUserResponse(string token, RefreshToken refreshToken) : base()
        {
            this.token = token;
            this.refreshToken = refreshToken;
        }

        public LoginUserResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public LoginUserResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
