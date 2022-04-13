using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListByWorkerIdQuery;
using MediatR;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListQuery
{
    public class GetRoleAssignmentListByWorkerIdQuery : IRequest<GetRoleAssignmentsListByWorkerIdResponse>
    {
        public int IdWorker { get; set; }
    }
}
