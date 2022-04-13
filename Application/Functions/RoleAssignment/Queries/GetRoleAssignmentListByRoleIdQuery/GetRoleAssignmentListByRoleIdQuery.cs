using MediatR;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentListByRoleIdQuery
{
    public class GetRoleAssignmentListByRoleIdQuery : IRequest<List<Domain.Models.RoleAssignment>>
    {
        public int IdRole { get; set; }
    }
}
