using MediatR;

namespace Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand
{
    public class CreateRoleAssignmentCommand : IRequest<CreateRoleAssignmentResponse>
    {
        public int IdRole { get; set; }
        public int IdWorker { get; set; }
    }
}
