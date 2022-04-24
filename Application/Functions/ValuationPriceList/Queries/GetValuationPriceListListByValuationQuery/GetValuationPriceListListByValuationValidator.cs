using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByValuationQuery
{
    public class GetValuationPriceListListByValuationValidator : AbstractValidator<GetValuationPriceListListByValuationQuery>
    {
        private readonly IApplicationContext _context;

        public GetValuationPriceListListByValuationValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesValuationExists)
                .WithMessage("Valuation with given id does not exist.");
        }

        private async Task<bool> DoesValuationExists(GetValuationPriceListListByValuationQuery command, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation != null;
        }
    }
}
