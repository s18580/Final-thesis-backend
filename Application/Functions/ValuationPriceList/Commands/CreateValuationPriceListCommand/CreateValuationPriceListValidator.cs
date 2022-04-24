using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ValuationPriceList.Commands.CreateValuationPriceListCommand
{
    public class CreateValuationPriceListValidator : AbstractValidator<CreateValuationPriceListCommand>
    {
        private readonly IApplicationContext _context;

        public CreateValuationPriceListValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesValuationPriceListExists)
                .WithMessage("Valuation price list with given ids does already exist.");

            RuleFor(p => p).
                MustAsync(DoesValuationExists)
                .WithMessage("Valuation with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesPriceListExists)
                .WithMessage("Price list with given id does not exist.");
        }

        private async Task<bool> DoesValuationPriceListExists(CreateValuationPriceListCommand command, CancellationToken cancellationToken)
        {
            var valuationPriceList = await _context.ValuationPriceLists
                                                   .Where(p => p.IdPriceList == command.IdPriceList)
                                                   .Where(p => p.IdValuation == command.IdValuation)
                                                   .SingleOrDefaultAsync();

            return valuationPriceList == null;
        }

        private async Task<bool> DoesValuationExists(CreateValuationPriceListCommand command, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation != null;
        }

        private async Task<bool> DoesPriceListExists(CreateValuationPriceListCommand command, CancellationToken cancellationToken)
        {
            var priceList = await _context.PriceLists
                                          .Where(p => p.IdPriceList == command.IdPriceList)
                                          .SingleOrDefaultAsync();

            return priceList != null;
        }
    }
}
