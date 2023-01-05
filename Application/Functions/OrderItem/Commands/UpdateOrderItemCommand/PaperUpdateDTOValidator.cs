using Domain.Enumerators;
using FluentValidation;

namespace Application.Functions.OrderItem.Commands.UpdateOrderItemCommand
{
    public class PaperUpdateDTOValidator : AbstractValidator<PaperUpdateDTO>
    {
        public PaperUpdateDTOValidator()
        {
            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Paper name is required.")
                   .NotEmpty()
                   .WithMessage("Paper name is required.")
                   .MaximumLength(100)
                   .WithMessage("Paper name length can't be longer then 100 characters.");

            RuleFor(p => p.Kind)
                   .NotNull()
                   .WithMessage("Kind is required.")
                   .NotEmpty()
                   .WithMessage("Kind is required.")
                   .MaximumLength(100)
                   .WithMessage("Kind length can't be longer then 100 characters.");

            RuleFor(p => p.SheetFormat)
                   .NotNull()
                   .WithMessage("Sheet format is required.")
                   .NotEmpty()
                   .WithMessage("Sheet format is required.")
                   .MaximumLength(20)
                   .WithMessage("Sheet format length can't be longer then 20 characters.");

            RuleFor(p => p.Opacity)
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.PricePerKilogram)
                .GreaterThan(0);

            RuleFor(p => p).
                MustAsync(DoesFiberDirectionExists)
                .WithMessage("Fiber direction with given id does not exist.");

        }

        private async Task<bool> DoesFiberDirectionExists(PaperUpdateDTO command, CancellationToken cancellationToken)
        {
            return Enum.IsDefined(typeof(FiberDirection), command.FiberDirection);
        }
    }
}
