using Application.Services;
using Domain.Enumerators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DTOs.DTOsValidators
{
    public class PaperDTOValidator : AbstractValidator<PaperDTO>
    {
        private readonly IApplicationContext _context;

        public PaperDTOValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Paper name is required.")
                   .NotEmpty()
                   .WithMessage("Paper name is required.")
                   .MaximumLength(255)
                   .WithMessage("Paper name length can't be longer then 255 characters.");

            RuleFor(p => p.Kind)
                   .NotNull()
                   .WithMessage("Kind is required.")
                   .NotEmpty()
                   .WithMessage("Kind is required.")
                   .MaximumLength(50)
                   .WithMessage("Kind length can't be longer then 50 characters.");

            RuleFor(p => p.SheetFormat)
                   .NotNull()
                   .WithMessage("Sheet format is required.")
                   .NotEmpty()
                   .WithMessage("Sheet format is required.")
                   .MaximumLength(100)
                   .WithMessage("Sheet format length can't be longer then 100 characters.");

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

        private async Task<bool> DoesFiberDirectionExists(PaperDTO command, CancellationToken cancellationToken)
        {
            return Enum.IsDefined(typeof(FiberDirection), command.FiberDirection);
        }
    }
}
