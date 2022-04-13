using MediatR;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentQuery
{
    public class GetRoleAssignmentQuery : IRequest<Domain.Models.RoleAssignment>
    {
        public int IdRole { get; set; }
        public int IdWorker { get; set; }
    }
}
