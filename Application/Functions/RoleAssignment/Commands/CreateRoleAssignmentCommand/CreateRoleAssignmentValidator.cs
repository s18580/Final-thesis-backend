using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand
{
    public class CreateRoleAssignmentValidator : AbstractValidator<CreateRoleAssignmentCommand>
    {
        private readonly IApplicationContext _context;

        public CreateRoleAssignmentValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesRoleAssignmentExists)
                .WithMessage("Role assignment with given ids does already exist.");

            RuleFor(p => p).
                MustAsync(DoesRoleExists)
                .WithMessage("Role  with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given id does not exist.");
        }

        private async Task<bool> DoesRoleAssignmentExists(CreateRoleAssignmentCommand command, CancellationToken cancellationToken)
        {
            var role = await _context.RoleAssignments
                                     .Where(p => p.IdRole == command.IdRole)
                                     .Where(p => p.IdWorker == command.IdWorker)
                                     .SingleOrDefaultAsync();

            return role == null;
        }

        private async Task<bool> DoesRoleExists(CreateRoleAssignmentCommand command, CancellationToken cancellationToken)
        {
            var role = await _context.Roles
                                     .Where(p => p.IdRole == command.IdRole)
                                     .SingleOrDefaultAsync();

            return role != null;
        }

        private async Task<bool> DoesWorkerExists(CreateRoleAssignmentCommand command, CancellationToken cancellationToken)
        {
            var role = await _context.Workers
                                     .Where(p => p.IdWorker == command.IdWorker)
                                     .SingleOrDefaultAsync();

            return role != null;
        }
    }
}
