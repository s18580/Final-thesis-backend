using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.PriceList.Commands.DeletePriceListCommand
{
    public class DeletePriceListValidator : AbstractValidator<DeletePriceListCommand>
    {
        private readonly IApplicationContext _context;

        public DeletePriceListValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesPriceListExists)
                .WithMessage("Price list with given id does not exist.");
        }

        private async Task<bool> DoesPriceListExists(DeletePriceListCommand command, CancellationToken cancellationToken)
        {
            var priceList = await _context.PriceLists
                                          .Where(p => p.IdPriceList == command.IdPriceList)
                                          .SingleOrDefaultAsync();

            return priceList != null;
        }
    }
}
