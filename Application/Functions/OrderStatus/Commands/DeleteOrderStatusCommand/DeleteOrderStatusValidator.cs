using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderStatus.Commands.DeleteOrderStatusCommand
{
    public class DeleteOrderStatusValidator : AbstractValidator<DeleteOrderStatusCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteOrderStatusValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderStatusExists)
                .WithMessage("Order status with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesOrdersExists)
                .WithMessage("Order status is still related with some orders.");
        }

        private async Task<bool> DoesOrderStatusExists(DeleteOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var orderStatus = await _context.OrderStatuses
                                     .Where(p => p.IdStatus == command.IdOrderStatus)
                                     .SingleOrDefaultAsync();

            return orderStatus != null;
        }

        private async Task<bool> DoesOrdersExists(DeleteOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                                       .Where(p => p.IdStatus == command.IdOrderStatus)
                                       .ToListAsync();

            return orders.Count == 0;
        }
    }
}
