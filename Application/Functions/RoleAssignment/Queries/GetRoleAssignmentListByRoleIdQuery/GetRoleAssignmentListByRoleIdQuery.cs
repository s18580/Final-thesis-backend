using MediatR;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentListByRoleIdQuery
{
    public class GetRoleAssignmentListByRoleIdQuery : IRequest<GetRoleAssignmentListByRoleIdResponse>
    {
        public int IdRole { get; set; }
    }
}
