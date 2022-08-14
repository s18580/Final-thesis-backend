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
                  .WithMessage("Order status name is required.")
                  .NotEmpty()
                  .WithMessage("Order status name is required.")
                  .MaximumLength(30)
                  .WithMessage("Order status name length can't be longer then 30 characters.");

            RuleFor(p => p.ChipColor)
                   .NotNull()
                   .WithMessage("Order status name is required.")
                   .NotEmpty()
                   .WithMessage("Order status name is required.")
                   .MaximumLength(8)
                   .WithMessage("Order status name length can't be longer then 8 characters.");

            RuleFor(p => p).
                MustAsync(IsOrderStatusNameUnique)
                .WithMessage("Order status with the same name already exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderStatusExists)
                .WithMessage("Order status with given id does not exist.");
        }

        private async Task<bool> IsOrderStatusNameUnique(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var orderStatus = await _context.OrderStatuses
                                            .Where(p => p.IdStatus == command.IdOrderStatus)
                                            .SingleOrDefaultAsync();

            if (command.Name != orderStatus.Name)
            {
                orderStatus = await _context.OrderStatuses
                                            .Where(x => x.Name == command.Name)
                                            .SingleOrDefaultAsync();

                return orderStatus == null;
            }

            return true;
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
