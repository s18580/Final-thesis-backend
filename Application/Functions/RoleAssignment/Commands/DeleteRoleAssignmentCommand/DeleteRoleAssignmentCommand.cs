using MediatR;

namespace Application.Functions.RoleAssignment.Commands.DeleteRoleAssignmentCommand
{
    public class DeleteRoleAssignmentCommand : IRequest<DeleteRoleAssignmentResponse>
    {
        public int IdRole { get; set; }
        public int IdWorker { get; set; }
    }
}
