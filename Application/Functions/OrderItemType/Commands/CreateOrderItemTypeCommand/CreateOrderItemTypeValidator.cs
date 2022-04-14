using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItemType.Commands.CreateOrderItemTypeCommand
{
    public class CreateOrderItemTypeValidator : AbstractValidator<CreateOrderItemTypeCommand>
    {
        private readonly IApplicationContext _context;

        public CreateOrderItemTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Order item type name is required.")
                   .NotEmpty()
                   .WithMessage("Order item type name is required.")
                   .MaximumLength(30)
                   .WithMessage("Order item type name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsOrderItemTypeNameUnique)
                .WithMessage("Order item type with the same name already exist");
        }

        private async Task<bool> IsOrderItemTypeNameUnique(CreateOrderItemTypeCommand command, CancellationToken cancellationToken)
        {
            var orderItemType = await _context.OrderItemTypes
                                     .Where(x => x.Name == command.Name)
                                     .SingleOrDefaultAsync();

            return orderItemType == null;
        }
    }
}
