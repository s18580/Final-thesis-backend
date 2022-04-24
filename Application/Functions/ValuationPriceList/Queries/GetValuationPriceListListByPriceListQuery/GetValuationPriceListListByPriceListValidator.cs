using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByPriceListQuery
{
    public class GetValuationPriceListListByPriceListValidator : AbstractValidator<GetValuationPriceListListByPriceListQuery>
    {
        private readonly IApplicationContext _context;

        public GetValuationPriceListListByPriceListValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesPriceListExists)
                .WithMessage("Price list with given id does not exist.");
        }

        private async Task<bool> DoesPriceListExists(GetValuationPriceListListByPriceListQuery command, CancellationToken cancellationToken)
        {
            var priceList = await _context.PriceLists
                                         .Where(p => p.IdPriceList == command.IdPriceList)
                                         .SingleOrDefaultAsync();

            return priceList != null;
        }
    }
}
