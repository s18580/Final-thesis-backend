using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Commands.CreateSupplyCommand
{
    public class CreateSupplyValidator : AbstractValidator<CreateSupplyCommand>
    {
        private readonly IApplicationContext _context;

        public CreateSupplyValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.ItemDescription)
                  .NotNull()
                  .WithMessage("Item description is required.")
                  .NotEmpty()
                  .WithMessage("Item description is required.")
                  .MaximumLength(255)
                  .WithMessage("Item description length can't be longer then 255 characters.");

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.Price)
                .GreaterThan(0);

            RuleFor(p => p).
                MustAsync(DoesSupplyItemTypeExists)
                .WithMessage("Supply item type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesRepresentativeExists)
                .WithMessage("Representative with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Order item with given id does not exist.");
        }

        private async Task<bool> DoesSupplyItemTypeExists(CreateSupplyCommand command, CancellationToken cancellationToken)
        {
            var supplyItemType = await _context.SupplyItemTypes
                                       .Where(p => p.IdSupplyItemType == command.IdSupplyItemType)
                                       .SingleOrDefaultAsync();

            return supplyItemType != null;
        }

        private async Task<bool> DoesRepresentativeExists(CreateSupplyCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                       .Where(p => p.IdRepresentative == command.IdRepresentative)
                                       .SingleOrDefaultAsync();

            return representative != null;
        }

        private async Task<bool> DoesOrderItemExists(CreateSupplyCommand command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                       .Where(p => p.IdOrderItem == command.IdOrderItem)
                                       .SingleOrDefaultAsync();

            return orderItem != null;
        }
    }
}
