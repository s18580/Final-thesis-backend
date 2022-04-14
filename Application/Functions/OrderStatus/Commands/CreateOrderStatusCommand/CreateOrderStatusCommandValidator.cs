using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand
{
    public class CreateOrderStatusCommandValidator : AbstractValidator<CreateOrderStatusCommand>
    {
        private readonly IApplicationContext _context;

        public CreateOrderStatusCommandValidator(IApplicationContext context)
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
                .WithMessage("Order status item type with the same name already exist");
        }

        private async Task<bool> IsOrderStatusNameUnique(CreateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var orderStatus = await _context.OrderStatuses
                                     .Where(x => x.Name == command.Name)
                                     .SingleOrDefaultAsync();

            return orderStatus == null;
        }
    }
}
