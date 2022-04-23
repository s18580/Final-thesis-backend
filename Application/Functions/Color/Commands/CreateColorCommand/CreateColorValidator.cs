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

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Color name is required.")
                   .NotEmpty()
                   .WithMessage("Color name is required.")
                   .MaximumLength(10)
                   .WithMessage("Color name length can't be longer then 10 characters.");

            RuleFor(p => p).
                MustAsync(DoesLinkExists)
                .WithMessage("Link with given id does not exist.");
        }

        private async Task<bool> DoesLinkExists(CreateColorCommand command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdLink)
                                          .SingleOrDefaultAsync();

            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdLink)
                                          .SingleOrDefaultAsync();

            return (orderItem != null || valuation != null);
        }
    }
}