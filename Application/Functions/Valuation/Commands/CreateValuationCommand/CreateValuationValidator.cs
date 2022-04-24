using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Commands.CreateValuationCommand
{
    public class CreateValuationValidator : AbstractValidator<CreateValuationCommand>
    {
        private readonly IApplicationContext _context;

        public CreateValuationValidator(IApplicationContext context)
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

            RuleFor(p => p.Circulation)
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.Capacity)
                .GreaterThanOrEqualTo(1);
            
            RuleFor(p => p.PrintingPlateNuber)
                .GreaterThanOrEqualTo(1);


            RuleFor(p => p.PrintPrice)
                .GreaterThan(0);

            RuleFor(p => p.UnitPriceNet)
                .GreaterThan(0);

            RuleFor(p => p.SamplePrintoutsPrice)
                .GreaterThan(0);

            RuleFor(p => p.GraphicDesignPrice)
                .GreaterThan(0);

            RuleFor(p => p.CoverSheetFormat)
                   .MaximumLength(100)
                   .WithMessage("Cover sheet format length can't be longer then 100 characters.");

            RuleFor(p => p).
                MustAsync(DoesBindingTypeExists)
                .WithMessage("Binding type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesAuthorExists)
                .WithMessage("Worker type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Order item type with given id does not exist.");
        }

        private async Task<bool> DoesBindingTypeExists(CreateValuationCommand command, CancellationToken cancellationToken)
        {
            var bindingType = await _context.BindingTypes
                                            .Where(p => p.IdBindingType == command.IdBindingType)
                                            .SingleOrDefaultAsync();

            return bindingType != null;
        }

        private async Task<bool> DoesAuthorExists(CreateValuationCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.IdWorker == command.IdAuthor)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }

        private async Task<bool> DoesOrderItemExists(CreateValuationCommand command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdOrderItem)
                                          .SingleOrDefaultAsync();

            return orderItem != null;
        }
    }
}
