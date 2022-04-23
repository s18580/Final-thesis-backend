using Application.Services;
using Domain.Enumerators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Commands.CreatePaperCommand
{
    public class CreatePaperValidator : AbstractValidator<CreatePaperCommand>
    {
        private readonly IApplicationContext _context;

        public CreatePaperValidator(IApplicationContext context)
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

            RuleFor(p => p).
                MustAsync(DoesFiberDirectionExists)
                .WithMessage("Fiber direction with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesLinkExists)
                .WithMessage("Link with given id does not exist.");
        }

        private async Task<bool> DoesLinkExists(CreatePaperCommand command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdLink)
                                          .SingleOrDefaultAsync();

            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdLink)
                                          .SingleOrDefaultAsync();

            return (orderItem != null || valuation != null);
        }

        private async Task<bool> DoesFiberDirectionExists(CreatePaperCommand command, CancellationToken cancellationToken)
        {
            return Enum.IsDefined(typeof(FiberDirection), command.FiberDirection);
        }
    }
}
