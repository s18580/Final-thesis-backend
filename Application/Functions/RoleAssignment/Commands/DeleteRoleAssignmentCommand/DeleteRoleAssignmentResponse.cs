using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.RoleAssignment.Commands.DeleteRoleAssignmentCommand
{
    public class DeleteRoleAssignmentResponse :BaseResponse
    {
        public DeleteRoleAssignmentResponse() : base()
        { }

        public DeleteRoleAssignmentResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteRoleAssignmentResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
