using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentQuery
{
    public class GetRoleAssignmentQueryHandler : IRequestHandler<GetRoleAssignmentQuery, Domain.Models.RoleAssignment>
    {
        private readonly IApplicationContext _context;

        public GetRoleAssignmentQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.RoleAssignment> Handle(GetRoleAssignmentQuery request, CancellationToken cancellationToken)
        {
            var roleAssignment = await _context.RoleAssignments
                                               .Where(p => p.IdRole == request.IdRole)
                                               .Where(p => p.IdWorker == request.IdWorker)
                                               .SingleOrDefaultAsync();

            return roleAssignment;
        }
    }
}
