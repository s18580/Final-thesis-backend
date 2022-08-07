using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.User.Commands.RegisterUserCommand
{
    public class RegisterUserResponse : BaseResponse
    {
        public int Id { get; }

        public RegisterUserResponse(int id) : base()
        {
            this.Id = id;
        }

        public RegisterUserResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public RegisterUserResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
