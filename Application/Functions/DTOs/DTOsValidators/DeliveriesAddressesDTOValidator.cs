using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DTOs.DTOsValidators
{
    public class DeliveriesAddressesDTOValidator : AbstractValidator<DeliveriesAddressesDTO>
    {
        private readonly IApplicationContext _context;

        public DeliveriesAddressesDTOValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesAddressExists)
                .WithMessage("Address with given id does not exist.");

        }

        private async Task<bool> DoesAddressExists(DeliveriesAddressesDTO command, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses
                                        .Where(p => p.IdAddress == command.IdAddress)
                                        .SingleOrDefaultAsync();

            return address != null;
        }
    }
}
