using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItemType.Commands.DeleteOrderItemTypeCommand
{
    public class DeleteOrderItemTypeValidator : AbstractValidator<DeleteOrderItemTypeCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteOrderItemTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderItemTypeExists)
                .WithMessage("Order item type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderItemsExists)
                .WithMessage("Order item type is still related with some order items.");
        }

        private async Task<bool> DoesOrderItemTypeExists(DeleteOrderItemTypeCommand command, CancellationToken cancellationToken)
        {
            var orderItemType = await _context.OrderItemTypes
                                     .Where(p => p.IdOrderItemType == command.IdOrderItemType)
                                     .SingleOrDefaultAsync();

            return orderItemType != null;
        }

        private async Task<bool> DoesOrderItemsExists(DeleteOrderItemTypeCommand command, CancellationToken cancellationToken)
        {
            var orderItems = await _context.OrderItems
                                     .Where(p => p.IdOrderItemType == command.IdOrderItemType)
                                     .ToListAsync();

            return orderItems.Count == 0;
        }
    }
}
