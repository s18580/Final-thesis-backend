using Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListQuery;
using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListByWorkerIdQuery
{
    public class GetRoleAssignmentsListByWorkerIdValidator : AbstractValidator<GetRoleAssignmentListByWorkerIdQuery>
    {
        private readonly IApplicationContext _context;

        public GetRoleAssignmentsListByWorkerIdValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given ids does not exist.");
        }

        private async Task<bool> DoesWorkerExists(GetRoleAssignmentListByWorkerIdQuery command, CancellationToken cancellationToken)
        {
            var worker = await _context.RoleAssignments
                                     .Where(p => p.IdWorker == command.IdWorker)
                                     .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
