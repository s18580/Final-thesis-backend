using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Commands.DisableAddressCommand
{
    public class DisableAddressValidator : AbstractValidator<DisableAddressCommand>
    {
        private readonly IApplicationContext _context;

        public DisableAddressValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesAddressExists)
                .WithMessage("Address with given id does not exist.");
        }

        private async Task<bool> DoesAddressExists(DisableAddressCommand command, CancellationToken cancellationToken)
        {
            var addresss = await _context.Addresses
                                       .Where(p => p.IdAddress == command.Id)
                                       .SingleOrDefaultAsync();

            return addresss != null;
        }
    }
}
