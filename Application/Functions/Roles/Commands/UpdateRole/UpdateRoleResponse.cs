using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Roles.Commands.UpdateRole
{
    public class UpdateRoleResponse : BaseResponse
    {
        public UpdateRoleResponse() : base()
        { }

        public UpdateRoleResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateRoleResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
