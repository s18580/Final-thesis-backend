using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Commands.DeleteColorCommand
{
    public class DeleteColorValidator : AbstractValidator<DeleteColorCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteColorValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesColorExists)
                .WithMessage("Color with given id does not exist.");
        }

        private async Task<bool> DoesColorExists(DeleteColorCommand command, CancellationToken cancellationToken)
        {
            var color = await _context.Colors
                                      .Where(p => p.IdColor == command.IdColor)
                                      .SingleOrDefaultAsync();

            return color != null;
        }
    }
}
