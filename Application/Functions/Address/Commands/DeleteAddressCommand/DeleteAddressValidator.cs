using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressValidator : AbstractValidator<DeleteAddressCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteAddressValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesAddressExists)
                .WithMessage("Address with given id does not exist.");
        }

        private async Task<bool> DoesAddressExists(DeleteAddressCommand command, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses
                                        .Where(p => p.IdAddress == command.IdAddress)
                                        .SingleOrDefaultAsync();

            return address != null;
        }
    }
}
