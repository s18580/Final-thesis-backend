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
                MustAsync(DoesSupplyItemTypeExists)
                .WithMessage("Order item type with given id does not exist.");
        }

        private async Task<bool> DoesSupplyItemTypeExists(DeleteOrderItemTypeCommand command, CancellationToken cancellationToken)
        {
            var orderItemType = await _context.OrderItemTypes
                                     .Where(p => p.IdOrderItemType == command.IdOrderItemType)
                                     .SingleOrDefaultAsync();

            return orderItemType != null;
        }
    }
}
