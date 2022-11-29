using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Commands.CreateColorCommand
{
    public class CreateColorValidator : AbstractValidator<CreateColorCommand>
    {
        private readonly IApplicationContext _context;

        public CreateColorValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesLinkIsGiven)
                .WithMessage("Specyfic link was not given.");

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Color name is required.")
                   .NotEmpty()
                   .WithMessage("Color name is required.")
                   .MaximumLength(20)
                   .WithMessage("Color name length can't be longer then 20 characters.");

            RuleFor(p => p.IsForCover)
                   .NotNull()
                   .WithMessage("IsForCover is required.");

            RuleFor(p => p).
                MustAsync(DoesLinkExists)
                .WithMessage("Link with given id does not exist.");
        }

        private async Task<bool> DoesLinkExists(CreateColorCommand command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdOrderItem)
                                          .SingleOrDefaultAsync();

            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdValuation)
                                          .SingleOrDefaultAsync();

            return (orderItem != null || valuation != null);
        }

        private async Task<bool> DoesLinkIsGiven(CreateColorCommand command, CancellationToken cancellationToken)
        {
            return !(command.IdValuation != null && command.IdOrderItem != null) || !(command.IdValuation == null && command.IdOrderItem == null);
        }
    }
}