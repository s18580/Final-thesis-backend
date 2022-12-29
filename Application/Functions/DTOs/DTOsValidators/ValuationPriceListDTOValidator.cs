using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DTOs.DTOsValidators
{
    public class ValuationPriceListDTOValidator : AbstractValidator<ValuationPriceListDTO>
    {
        private readonly IApplicationContext _context;

        public ValuationPriceListDTOValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesPriceListExists)
                .WithMessage("Price list with given id does not exist.");

            RuleFor(p => p.UsedPrice)
                .GreaterThanOrEqualTo(0);

        }

        private async Task<bool> DoesPriceListExists(ValuationPriceListDTO command, CancellationToken cancellationToken)
        {
            var priceList = await _context.PriceLists
                                          .Where(p => p.IdPriceList == command.IdPriceList)
                                          .SingleOrDefaultAsync();

            return priceList != null;
        }
    }
}
