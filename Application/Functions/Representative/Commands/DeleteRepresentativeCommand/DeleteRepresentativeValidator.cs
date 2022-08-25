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

            RuleFor(p => p).
                MustAsync(HasConnectedItems)
                .WithMessage("Until representative is connected with orders or supplies, he cannot be deleted.");
        }

        private async Task<bool> DoesRepresentativeExists(DeleteRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                               .Where(p => p.IdRepresentative == command.IdRepresentative)
                                               .SingleOrDefaultAsync();

            return representative != null;
        }

        private async Task<bool> HasConnectedItems(DeleteRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                               .Where(p => p.IdRepresentative == command.IdRepresentative)
                                               .SingleAsync();

            if (representative.IdCustomer == null)
            {
                var supplies = await _context.Supplies
                                             .Where(p => p.IdRepresentative == command.IdRepresentative)
                                             .ToListAsync();

                return supplies.Count == 0;
            }
            else
            {
                var orders = await _context.Orders
                                           .Where(p => p.IdRepresentative == command.IdRepresentative)
                                           .ToListAsync();

                return orders.Count == 0;
            }
        }
    }
}
