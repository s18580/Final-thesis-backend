using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Commands.UpdateColorCommand
{
    public class UpdateColorValidator : AbstractValidator<UpdateColorCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateColorValidator(IApplicationContext context)
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
                MustAsync(DoesColorExists)
                .WithMessage("Color with given id does not exist.");
        }

        private async Task<bool> DoesColorExists(UpdateColorCommand command, CancellationToken cancellationToken)
        {
            var color = await _context.Colors
                                      .Where(p => p.IdColor == command.IdColor)
                                      .SingleOrDefaultAsync();

            return color != null;
        }
    }
}
