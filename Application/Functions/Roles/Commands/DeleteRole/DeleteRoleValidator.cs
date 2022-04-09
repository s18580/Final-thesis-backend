using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Roles.Commands.DeleteRole
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteRoleValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(IsRoleExists)
                .WithMessage("Role with given id does not exist");
        }

        private async Task<bool> IsRoleExists(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            var role = await _context.Roles
                                       .Where(p => p.IdRole == command.Id)
                                       .SingleOrDefaultAsync();

            return role != null;
        }
    }
}
