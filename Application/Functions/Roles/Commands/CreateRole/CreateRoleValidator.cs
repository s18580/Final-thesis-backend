using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Roles.Commands.CreateRole
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        private readonly IApplicationContext _context;

        public CreateRoleValidator(IApplicationContext context)
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
        }

        private async Task<bool> IsRoleNameUnique(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.Where(x => x.Name == command.Name).SingleOrDefaultAsync();

            return role == null;
        }
    }
}
