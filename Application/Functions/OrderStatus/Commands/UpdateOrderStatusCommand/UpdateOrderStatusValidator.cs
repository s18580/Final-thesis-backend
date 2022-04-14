using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderStatus.Commands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateOrderStatusValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("Order status item type name is required.")
                  .NotEmpty()
                  .WithMessage("Order status item type name is required.")
                  .MaximumLength(30)
                  .WithMessage("Order status item type name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsOrderStatusNameUnique)
                .WithMessage("Order status item type with the same name already exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderStatusExists)
                .WithMessage("Order status with given id does not exist.");
        }

        private async Task<bool> IsOrderStatusNameUnique(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var orderStatus = await _context.OrderStatuses
                                         .Where(x => x.Name == command.Name)
                                         .SingleOrDefaultAsync();

            return orderStatus == null;
        }

        private async Task<bool> DoesOrderStatusExists(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var orderStatus = await _context.OrderStatuses
                                         .Where(p => p.IdStatus == command.IdOrderStatus)
                                         .SingleOrDefaultAsync();

            return orderStatus != null;
        }
    }
}
