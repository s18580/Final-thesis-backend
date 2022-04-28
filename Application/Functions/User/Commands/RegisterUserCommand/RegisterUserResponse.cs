using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.User.Commands.RegisterUserCommand
{
    public class RegisterUserResponse : BaseResponse
    {
        public LoggedUserDTO loggedUserData { get; set; }

        public RegisterUserResponse(LoggedUserDTO data) : base()
        {
            loggedUserData = data;
        }

        public RegisterUserResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public RegisterUserResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
