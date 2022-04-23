using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Queries.GetPaperListByValuationQuery
{
    public class GetPaperListByValuationValidator : AbstractValidator<GetPaperListByValuationQuery>
    {
        private readonly IApplicationContext _context;

        public GetPaperListByValuationValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesValuationExists)
                .WithMessage("Valuation with given id does not exist.");
        }

        private async Task<bool> DoesValuationExists(GetPaperListByValuationQuery command, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation != null;
        }
    }
}
