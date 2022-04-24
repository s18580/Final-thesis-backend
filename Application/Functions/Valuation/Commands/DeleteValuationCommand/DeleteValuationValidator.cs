using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Commands.DeleteValuationCommand
{
    public class DeleteValuationValidator : AbstractValidator<DeleteValuationCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteValuationValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesValuationExists)
                .WithMessage("Valuation with given id does not exist.");
        }

        private async Task<bool> DoesValuationExists(DeleteValuationCommand command, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation != null;
        }
    }
}
