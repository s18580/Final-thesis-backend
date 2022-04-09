using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Roles.Commands.UpdateRole
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateRoleValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Role name is required.")
                   .NotEmpty()
                   .WithMessage("Role name is required.")
                   .MaximumLength(10)
                   .WithMessage("Role name length can't be longer then 10 characters.");

            RuleFor(p => p).
                MustAsync(IsRoleNameUnique)
                .WithMessage("Role with the same name already exist");

            RuleFor(p => p).
                MustAsync(DoesRoleExists)
                .WithMessage("Role with given id does not exist");
        }

        private async Task<bool> IsRoleNameUnique(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            var worksite = await _context.Roles
                                         .Where(x => x.Name == command.Name)
                                         .SingleOrDefaultAsync();

            return worksite == null;
        }

        private async Task<bool> DoesRoleExists(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            var worksite = await _context.Roles
                                         .Where(p => p.IdRole == command.Id)
                                         .SingleOrDefaultAsync();

            return worksite != null;
        }
    }
}
