using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ValuationPriceList.Commands.DeleteValuationPriceListCommand
{
    public class DeleteValuationPriceListValidator : AbstractValidator<DeleteValuationPriceListCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteValuationPriceListValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesValuationPriceListExists)
                .WithMessage("Valuation price list with given ids does already exist.");
        }

        private async Task<bool> DoesValuationPriceListExists(DeleteValuationPriceListCommand command, CancellationToken cancellationToken)
        {
            var valuationPriceList = await _context.ValuationPriceLists
                                                   .Where(p => p.IdPriceList == command.IdPriceList)
                                                   .Where(p => p.IdValuation == command.IdValuation)
                                                   .SingleOrDefaultAsync();

            return valuationPriceList == null;
        }
    }
}
