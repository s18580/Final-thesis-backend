using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Roles.Commands.CreateRole
{
    public class CreateRoleResponse : BaseResponse
    {
        public CreateRoleResponse() : base()
        { }

        public CreateRoleResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateRoleResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
