using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentListByRoleIdQuery
{
    public class GetRoleAssignmentListByRoleIdQueryHandler : IRequestHandler<GetRoleAssignmentListByRoleIdQuery, GetRoleAssignmentListByRoleIdResponse>
    {
        private readonly IApplicationContext _context;
        public GetRoleAssignmentListByRoleIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetRoleAssignmentListByRoleIdResponse> Handle(GetRoleAssignmentListByRoleIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetRoleAssignmentListByRoleIdValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetRoleAssignmentListByRoleIdResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var roleAssignments = await _context.RoleAssignments
                                                .Where(p => p.IdRole == request.IdRole)
                                                .ToListAsync();

            return new GetRoleAssignmentListByRoleIdResponse(roleAssignments);
        }
    }
}
