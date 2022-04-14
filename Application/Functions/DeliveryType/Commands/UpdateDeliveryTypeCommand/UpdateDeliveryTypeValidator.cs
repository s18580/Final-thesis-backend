using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveryType.Commands.UpdateDeliveryTypeCommand
{
    public class UpdateDeliveryTypeValidator : AbstractValidator<UpdateDeliveryTypeCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateDeliveryTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("Delivery type item type name is required.")
                  .NotEmpty()
                  .WithMessage("Delivery type item type name is required.")
                  .MaximumLength(30)
                  .WithMessage("Delivery type item type name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsDeliveryTypeNameUnique)
                .WithMessage("Delivery type item type with the same name already exist");

            RuleFor(p => p).
                MustAsync(DoesDeliveryTypeExists)
                .WithMessage("Delivery type with given id does not exist");
        }

        private async Task<bool> IsDeliveryTypeNameUnique(UpdateDeliveryTypeCommand command, CancellationToken cancellationToken)
        {
            var deliveryType = await _context.DeliveryTypes
                                         .Where(x => x.Name == command.Name)
                                         .SingleOrDefaultAsync();

            return deliveryType == null;
        }

        private async Task<bool> DoesDeliveryTypeExists(UpdateDeliveryTypeCommand command, CancellationToken cancellationToken)
        {
            var deliveryType = await _context.DeliveryTypes
                                         .Where(p => p.IdDeliveryType == command.IdDeliveryType)
                                         .SingleOrDefaultAsync();

            return deliveryType != null;
        }
    }
}
