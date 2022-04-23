using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Queries.GetColorListByValuationQuery
{
    public class GetColorListByValuationValidator : AbstractValidator<GetColorListByValuationQuery>
    {
        private readonly IApplicationContext _context;

        public GetColorListByValuationValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesValuationExists)
                .WithMessage("Valuation with given id does not exist.");
        }

        private async Task<bool> DoesValuationExists(GetColorListByValuationQuery command, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation != null;
        }
    }
}
