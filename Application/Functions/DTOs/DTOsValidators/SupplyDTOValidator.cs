using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DTOs.DTOsValidators
{
    public class SupplyDTOValidator : AbstractValidator<SupplyDTO>
    {
        private readonly IApplicationContext _context;

        public SupplyDTOValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.ItemDescription)
                   .NotNull()
                   .WithMessage("Item describtion is required.")
                   .NotEmpty()
                   .WithMessage("Item describtion is required.")
                   .MaximumLength(255)
                   .WithMessage("Item describtion length can't be longer then 255 characters.");

            RuleFor(p => p.Price)
                   .NotNull()
                   .WithMessage("Price is required.");

            RuleFor(p => p.Quantity)
                   .NotNull()
                   .WithMessage("Quantity is required.");

            RuleFor(p => p.SupplyDate)
                   .NotNull()
                   .WithMessage("SupplyDate is required.");

            RuleFor(p => p.IsReceived)
                   .NotNull()
                   .WithMessage("IsReceived is required.");

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Address with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderItemTypeExists)
                .WithMessage("Address with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesRepresentativeExists)
                .WithMessage("Address with given id does not exist.");

        }

        private async Task<bool> DoesOrderItemExists(SupplyDTO command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                        .Where(p => p.IdOrderItem == command.IdOrderItem)
                                        .SingleOrDefaultAsync();

            return orderItem != null;
        }

        private async Task<bool> DoesOrderItemTypeExists(SupplyDTO command, CancellationToken cancellationToken)
        {
            var type = await _context.SupplyItemTypes
                                        .Where(p => p.IdSupplyItemType == command.IdSupplyItemType)
                                        .SingleOrDefaultAsync();

            return type != null;
        }

        private async Task<bool> DoesRepresentativeExists(SupplyDTO command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                        .Where(p => p.IdRepresentative == command.IdRepresentative)
                                        .SingleOrDefaultAsync();

            return representative != null;
        }
    }
}
