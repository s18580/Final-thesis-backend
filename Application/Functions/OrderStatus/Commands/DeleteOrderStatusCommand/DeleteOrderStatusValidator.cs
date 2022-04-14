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
        }

        private async Task<bool> DoesOrderStatusExists(DeleteOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var orderStatus = await _context.OrderStatuses
                                     .Where(p => p.IdStatus == command.IdOrderStatus)
                                     .SingleOrDefaultAsync();

            return orderStatus != null;
        }
    }
}
