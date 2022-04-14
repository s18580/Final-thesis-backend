using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand
{
    public class CreateDeliveryTypeValidator : AbstractValidator<CreateDeliveryTypeCommand>
    {
        private readonly IApplicationContext _context;

        public CreateDeliveryTypeValidator(IApplicationContext context)
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
        }

        private async Task<bool> IsDeliveryTypeNameUnique(CreateDeliveryTypeCommand command, CancellationToken cancellationToken)
        {
            var deliveryType = await _context.DeliveryTypes
                                     .Where(x => x.Name == command.Name)
                                     .SingleOrDefaultAsync();

            return deliveryType == null;
        }
    }
}
