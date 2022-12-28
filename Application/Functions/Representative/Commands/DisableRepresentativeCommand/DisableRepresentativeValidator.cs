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

            RuleFor(p => p).
                MustAsync(CanBeDisabled)
                .WithMessage("You cannot disable main representative of person client.");
        }

        private async Task<bool> DoesRepresentativeExists(DisableRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                       .Where(p => p.IdRepresentative == command.Id)
                                       .SingleOrDefaultAsync();

            return representative != null;
        }

        private async Task<bool> CanBeDisabled(DisableRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                       .Include(p => p.Customer)
                                       .Where(p => p.IdRepresentative == command.Id)
                                       .SingleOrDefaultAsync();



            return representative.Name + " " + representative.LastName != representative.Customer.CompanyName;
        }
    }
}
