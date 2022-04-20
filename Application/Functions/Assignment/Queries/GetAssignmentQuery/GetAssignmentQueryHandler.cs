using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Queries.GetAssignmentQuery
{
    public class GetAssignmentQueryHandler : IRequestHandler<GetAssignmentQuery, Domain.Models.Assignment>
    {
        private readonly IApplicationContext _context;

        public GetAssignmentQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Assignment> Handle(GetAssignmentQuery request, CancellationToken cancellationToken)
        {
            var assignment = await _context.Assignments
                                           .Where(p => p.IdWorker == request.IdWorker)
                                           .Where(p => p.IdOrder == request.IdOrder)
                                           .SingleOrDefaultAsync();

            return assignment;
        }
    }
}
