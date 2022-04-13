using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentListByRoleIdQuery
{
    public class GetRoleAssignmentListByRoleIdValidator : AbstractValidator<GetRoleAssignmentListByRoleIdQuery>
    {
        private readonly IApplicationContext _context;

        public GetRoleAssignmentListByRoleIdValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesRoleExists)
                .WithMessage("Role with given ids does not exist.");
        }

        private async Task<bool> DoesRoleExists(GetRoleAssignmentListByRoleIdQuery command, CancellationToken cancellationToken)
        {
            var role = await _context.RoleAssignments
                                     .Where(p => p.IdRole == command.IdRole)
                                     .SingleOrDefaultAsync();

            return role != null;
        }
    }
}
