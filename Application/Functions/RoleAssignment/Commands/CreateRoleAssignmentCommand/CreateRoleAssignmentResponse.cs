using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand
{
    public class CreateRoleAssignmentResponse : BaseResponse
    {
        public CreateRoleAssignmentResponse() : base()
        { }

        public CreateRoleAssignmentResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateRoleAssignmentResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
