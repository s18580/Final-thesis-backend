using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Commands.DeleteOrderItemCommand
{
    public class DeleteOrderItemValidator : AbstractValidator<DeleteOrderItemCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteOrderItemValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Order item with given id does not exist.");
        }

        private async Task<bool> DoesOrderItemExists(DeleteOrderItemCommand command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdOrderItem)
                                          .SingleOrDefaultAsync();

            return orderItem != null;
        }
    }
}
