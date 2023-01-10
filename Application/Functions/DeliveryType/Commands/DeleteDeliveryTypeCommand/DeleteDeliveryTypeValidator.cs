using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveryType.Commands.DeleteDeliveryTypeCommand
{
    public class DeleteDeliveryTypeValidator : AbstractValidator<DeleteDeliveryTypeCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteDeliveryTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesDeliveryTypeExists)
                .WithMessage("Delivery type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderItemsExists)
                .WithMessage("Delivery type is still related with some order items.");
        }

        private async Task<bool> DoesDeliveryTypeExists(DeleteDeliveryTypeCommand command, CancellationToken cancellationToken)
        {
            var deliveryType = await _context.DeliveryTypes
                                     .Where(p => p.IdDeliveryType == command.IdDeliveryType)
                                     .SingleOrDefaultAsync();

            return deliveryType != null;
        }

        private async Task<bool> DoesOrderItemsExists(DeleteDeliveryTypeCommand command, CancellationToken cancellationToken)
        {
            var orders = await _context.OrderItems
                                     .Where(p => p.IdDeliveryType == command.IdDeliveryType)
                                     .ToListAsync();

            return orders.Count == 0;
        }
    }
}
