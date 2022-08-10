using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.User.Commands.RegisterUserWithRolesCommand
{
    public class RegisterUserWithRolesResponse : BaseResponse
    {
        public int Id { get; }

        public RegisterUserWithRolesResponse(int id) : base()
        {
            this.Id = id;
        }

        public RegisterUserWithRolesResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public RegisterUserWithRolesResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
