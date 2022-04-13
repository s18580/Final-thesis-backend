using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Commands.DeleteRoleAssignmentCommand
{
    public class DeleteRoleAssignmentValidator : AbstractValidator<DeleteRoleAssignmentCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteRoleAssignmentValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesRoleAssignmentExists)
                .WithMessage("Role assignment with given ids does not exist.");
        }

        private async Task<bool> DoesRoleAssignmentExists(DeleteRoleAssignmentCommand command, CancellationToken cancellationToken)
        {
            var roleAssignment = await _context.RoleAssignments
                                     .Where(p => p.IdRole == command.IdRole)
                                     .Where(p => p.IdWorker == command.IdWorker)
                                     .SingleOrDefaultAsync();

            return roleAssignment != null;
        }
    }
}
