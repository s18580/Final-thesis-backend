using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Commands.DeleteOrderCommand
{
    public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteOrderValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderExists)
                .WithMessage("Order with given id does not exist.");
        }

        private async Task<bool> DoesOrderExists(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                                           .Where(p => p.IdOrder == command.IdOrder)
                                           .SingleOrDefaultAsync();

            return order != null;
        }
    }
}
