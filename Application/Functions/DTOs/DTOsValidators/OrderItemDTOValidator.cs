using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DTOs.DTOsValidators
{
    public class OrderItemDTOValidator : AbstractValidator<OrderItemDTO>
    {
        private readonly IApplicationContext _context;

        public OrderItemDTOValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Delivery type name is required.")
                   .NotEmpty()
                   .WithMessage("Delivery typename is required.")
                   .MaximumLength(255)
                   .WithMessage("Delivery type name length can't be longer then 255 characters.");

            RuleFor(p => p.Comments)
                   .MaximumLength(255)
                   .WithMessage("Delivery type name length can't be longer then 255 characters.");

            RuleFor(p => p.CoverFormat)
                   .MaximumLength(100)
                   .WithMessage("Delivery type name length can't be longer then 100 characters.");

            RuleFor(p => p.InsideFormat)
                   .NotNull()
                   .WithMessage("Delivery type name is required.")
                   .NotEmpty()
                   .WithMessage("Delivery typename is required.")
                   .MaximumLength(100)
                   .WithMessage("Delivery type name length can't be longer then 100 characters.");

            RuleFor(p => p.Circulation)
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.Capacity)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p).
                MustAsync(DoesOrderItemTypeExists)
                .WithMessage("Order item type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesDeliveryTypeExists)
                .WithMessage("Delivery type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesBindingTypeExists)
                .WithMessage("Binding type with given id does not exist.");
        }

        private async Task<bool> DoesOrderItemTypeExists(OrderItemDTO command, CancellationToken cancellationToken)
        {
            var orderItemType = await _context.OrderItemTypes
                                              .Where(p => p.IdOrderItemType == command.IdOrderItemType)
                                              .SingleOrDefaultAsync();

            return orderItemType != null;
        }

        private async Task<bool> DoesDeliveryTypeExists(OrderItemDTO command, CancellationToken cancellationToken)
        {
            var deliveryType = await _context.DeliveryTypes
                                             .Where(p => p.IdDeliveryType == command.IdDeliveryType)
                                             .SingleOrDefaultAsync();

            return deliveryType != null;
        }

        private async Task<bool> DoesBindingTypeExists(OrderItemDTO command, CancellationToken cancellationToken)
        {
            if (command.IdBindingType == null)
            {
                return true;
            }

            var bindingType = await _context.BindingTypes
                                            .Where(p => p.IdBindingType == command.IdBindingType)
                                            .SingleOrDefaultAsync();

            return bindingType != null;
        }
    }

}
