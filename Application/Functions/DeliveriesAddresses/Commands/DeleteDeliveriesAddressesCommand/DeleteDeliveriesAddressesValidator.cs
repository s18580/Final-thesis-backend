using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Commands.DeleteDeliveriesAddressesCommand
{
    public class DeleteDeliveriesAddressesValidator : AbstractValidator<DeleteDeliveriesAddressesCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteDeliveriesAddressesValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesDeliveriesAddressesExists)
                .WithMessage("Deliveries addresses with given id does already exist.");
        }

        private async Task<bool> DoesDeliveriesAddressesExists(DeleteDeliveriesAddressesCommand command, CancellationToken cancellationToken)
        {
            var deliveriesAddress = await _context.DeliveriesAddresses
                                                  .Where(p => p.IdDeliveriesAddresses == command.IdDeliveriesAddresses)
                                                  .SingleOrDefaultAsync();

            return deliveriesAddress != null;
        }
    }
}
