using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItemType.Commands.UpdateOrderItemTypeCommand
{
    public class UpdateOrderItemTypeValidator : AbstractValidator<UpdateOrderItemTypeCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateOrderItemTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("Order item type item type name is required.")
                  .NotEmpty()
                  .WithMessage("Order item type item type name is required.")
                  .MaximumLength(30)
                  .WithMessage("Order item type item type name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsOrderItemTypeNameUnique)
                .WithMessage("Order item type item type with the same name already exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderItemTypeExists)
                .WithMessage("Order item type with given id does not exist.");
        }

        private async Task<bool> IsOrderItemTypeNameUnique(UpdateOrderItemTypeCommand command, CancellationToken cancellationToken)
        {
            var orderItemType = await _context.OrderItemTypes
                                         .Where(x => x.Name == command.Name)
                                         .SingleOrDefaultAsync();

            return orderItemType == null;
        }

        private async Task<bool> DoesOrderItemTypeExists(UpdateOrderItemTypeCommand command, CancellationToken cancellationToken)
        {
            var orderItemType = await _context.OrderItemTypes
                                         .Where(p => p.IdOrderItemType == command.IdOrderItemType)
                                         .SingleOrDefaultAsync();

            return orderItemType != null;
        }
    }
}
