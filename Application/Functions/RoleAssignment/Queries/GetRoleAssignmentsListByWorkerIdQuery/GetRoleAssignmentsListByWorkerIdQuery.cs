using MediatR;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListQuery
{
    public class GetRoleAssignmentsListByWorkerIdQuery : IRequest<List<Domain.Models.RoleAssignment>>
    {
        public int IdWorker { get; set; }
    }
}
