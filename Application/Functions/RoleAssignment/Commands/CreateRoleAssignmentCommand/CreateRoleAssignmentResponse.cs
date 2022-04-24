using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand
{
    public class CreateRoleAssignmentResponse : BaseResponse
    {
        public int IdWorker { get; }
        public int IdRole { get; }

        public CreateRoleAssignmentResponse(int idWorker, int idRole) : base()
        {
            IdWorker = idWorker;
            IdRole = idRole;
        }

        public CreateRoleAssignmentResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateRoleAssignmentResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
