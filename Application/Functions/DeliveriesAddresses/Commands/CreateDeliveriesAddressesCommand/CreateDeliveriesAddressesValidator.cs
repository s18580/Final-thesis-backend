using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Commands.CreateDeliveriesAddressesCommand
{
    public class CreateDeliveriesAddressesValidator : AbstractValidator<CreateDeliveriesAddressesCommand>
    {
        private readonly IApplicationContext _context;

        public CreateDeliveriesAddressesValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesDeliveriesAddressesExists)
                .WithMessage("Deliveries addresses with given ids does already exist.");

            RuleFor(p => p).
                MustAsync(DoesAddressExists)
                .WithMessage("Address with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesLinkExists)
                .WithMessage("Link with given id does not exist.");
        }

        private async Task<bool> DoesDeliveriesAddressesExists(CreateDeliveriesAddressesCommand command, CancellationToken cancellationToken)
        {
            if (command.IdOrder != null)
            {
                var deliveriesAddress = await _context.DeliveriesAddresses
                                                      .Where(p => p.IdAddress == command.IdAddress)
                                                      .Where(p => p.IdOrder == command.IdOrder)
                                                      .SingleOrDefaultAsync();
                return deliveriesAddress == null;

            } else if (command.IdSupply != null)
            {
                var deliveriesAddress = await _context.DeliveriesAddresses
                                                      .Where(p => p.IdAddress == command.IdAddress)
                                                      .Where(p => p.IdSupply == command.IdSupply)
                                                      .SingleOrDefaultAsync();
                return deliveriesAddress == null;

            } else
            {
                return false;
            }
        }

        private async Task<bool> DoesAddressExists(CreateDeliveriesAddressesCommand command, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses
                                        .Where(p => p.IdAddress == command.IdAddress)
                                        .SingleOrDefaultAsync();

            return address != null;
        }

        private async Task<bool> DoesLinkExists(CreateDeliveriesAddressesCommand command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                                      .Where(p => p.IdOrder == command.IdOrder)
                                      .SingleOrDefaultAsync();

            var supply = await _context.Supplies
                                       .Where(p => p.IdSupply == command.IdSupply)
                                       .SingleOrDefaultAsync();

            return (order != null || supply != null);
        }
    }
}
