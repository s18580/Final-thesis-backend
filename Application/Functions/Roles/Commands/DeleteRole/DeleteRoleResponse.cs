using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Roles.Commands.DeleteRole
{
    public class DeleteRoleResponse : BaseResponse
    {
        public DeleteRoleResponse() : base()
        { }

        public DeleteRoleResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteRoleResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
