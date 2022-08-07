using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.User.Queries.LoginUserQuery
{
    public class LoginUserResponse : BaseResponse
    {
        public int userId { get; set; }
        public List<string> userRoles { get; set; }
        public string userName { get; set; }
        public string token { get; set; }
        public RefreshToken refreshToken { get; set; }

        public LoginUserResponse(string token, RefreshToken refreshToken, string name, List<string> roles, int id) : base()
        {
            this.userId = id;
            this.userName = name;
            this.token = token;
            this.refreshToken = refreshToken;
            this.userRoles = roles;
        }

        public LoginUserResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public LoginUserResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
