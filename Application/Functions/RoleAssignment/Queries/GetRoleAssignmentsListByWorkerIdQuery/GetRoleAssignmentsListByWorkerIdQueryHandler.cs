using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListQuery
{
    public class GetRoleAssignmentsListByWorkerIdQueryHandler : IRequestHandler<GetRoleAssignmentsListByWorkerIdQuery, List<Domain.Models.RoleAssignment>>
    {
        private readonly IApplicationContext _context;

        public GetRoleAssignmentsListByWorkerIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.RoleAssignment>> Handle(GetRoleAssignmentsListByWorkerIdQuery request, CancellationToken cancellationToken)
        {
            var roleAssignments = await _context.RoleAssignments
                                                .Where(p => p.IdWorker == request.IdWorker)
                                                .ToListAsync();

            return roleAssignments;
        }
    }
}
