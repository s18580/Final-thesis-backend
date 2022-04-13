using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentListByRoleIdQuery
{
    public class GetRoleAssignmentListByRoleIdQueryHandler : IRequestHandler<GetRoleAssignmentListByRoleIdQuery, List<Domain.Models.RoleAssignment>>
    {
        private readonly IApplicationContext _context;
        public GetRoleAssignmentListByRoleIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.RoleAssignment>> Handle(GetRoleAssignmentListByRoleIdQuery request, CancellationToken cancellationToken)
        {
            var roleAssignments = await _context.RoleAssignments
                                                .Where(p => p.IdWorker == request.IdRole)
                                                .ToListAsync();

            return roleAssignments;
        }
    }
}
