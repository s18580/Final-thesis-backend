using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Commands.DeleteRepresentativeCommand
{
    public class DeleteRepresentativeValidator : AbstractValidator<DeleteRepresentativeCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteRepresentativeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesRepresentativeExists)
                .WithMessage("Representative with given id does not exist.");
        }

        private async Task<bool> DoesRepresentativeExists(DeleteRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                               .Where(p => p.IdRepresentative == command.IdRepresentative)
                                               .SingleOrDefaultAsync();

            return representative != null;
        }
    }
}
