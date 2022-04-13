using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListByWorkerIdQuery;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListQuery
{
    public class GetRoleAssignmentsListByWorkerIdQueryHandler : IRequestHandler<GetRoleAssignmentListByWorkerIdQuery, GetRoleAssignmentsListByWorkerIdResponse>
    {
        private readonly IApplicationContext _context;

        public GetRoleAssignmentsListByWorkerIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetRoleAssignmentsListByWorkerIdResponse> Handle(GetRoleAssignmentListByWorkerIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetRoleAssignmentsListByWorkerIdValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetRoleAssignmentsListByWorkerIdResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var roleAssignments = await _context.RoleAssignments
                                                .Where(p => p.IdWorker == request.IdWorker)
                                                .ToListAsync();

            return new GetRoleAssignmentsListByWorkerIdResponse(roleAssignments);
        }
    }
}
