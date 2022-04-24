using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Commands.UpdateValuationCommand
{
    public class UpdateValuationValidator : AbstractValidator<UpdateValuationCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateValuationValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Valuation name is required.")
                   .NotEmpty()
                   .WithMessage("Valuation name is required.")
                   .MaximumLength(255)
                   .WithMessage("Valuation name length can't be longer then 255 characters.");

            RuleFor(p => p.InsideFormat)
                   .NotNull()
                   .WithMessage("Inside format is required.")
                   .NotEmpty()
                   .WithMessage("Inside format is required.")
                   .MaximumLength(100)
                   .WithMessage("Inside format length can't be longer then 100 characters.");

            RuleFor(p => p.CoverFormat)
                   .MaximumLength(100)
                   .WithMessage("Cover format length can't be longer then 100 characters.");

            RuleFor(p => p.InsideSheetFormat)
                   .NotNull()
                   .WithMessage("Inside sheet format is required.")
                   .NotEmpty()
                   .WithMessage("Inside sheet format is required.")
                   .MaximumLength(100)
                   .WithMessage("Inside sheet format length can't be longer then 100 characters.");

            RuleFor(p => p.CoverSheetFormat)
                   .MaximumLength(100)
                   .WithMessage("Cover sheet format length can't be longer then 100 characters.");

            RuleFor(p => p).
                MustAsync(DoesValuationExists)
                .WithMessage("Valuation with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesBindingTypeExists)
                .WithMessage("Binding type with given id does not exist.");
        }

        private async Task<bool> DoesValuationExists(UpdateValuationCommand command, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation != null;
        }

        private async Task<bool> DoesBindingTypeExists(UpdateValuationCommand command, CancellationToken cancellationToken)
        {
            var bindingType = await _context.BindingTypes
                                            .Where(p => p.IdBindingType == command.IdBindingType)
                                            .SingleOrDefaultAsync();

            return bindingType != null;
        }
    }
}
