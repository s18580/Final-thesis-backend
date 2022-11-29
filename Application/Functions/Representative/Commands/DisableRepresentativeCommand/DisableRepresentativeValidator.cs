using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Commands.DisableRepresentativeCommand
{
    public class DisableRepresentativeValidator : AbstractValidator<DisableRepresentativeCommand>
    {
        private readonly IApplicationContext _context;

        public DisableRepresentativeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesRepresentativeExists)
                .WithMessage("Representative with given id does not exist.");
        }

        private async Task<bool> DoesRepresentativeExists(DisableRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                       .Where(p => p.IdRepresentative == command.Id)
                                       .SingleOrDefaultAsync();

            return representative != null;
        }
    }
}
