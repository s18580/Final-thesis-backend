using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.PriceList.Commands.UpdatePriceListCommand
{
    public class UpdatePriceListValuationValidator : AbstractValidator<UpdatePriceListCommand>
    {
        private readonly IApplicationContext _context;

        public UpdatePriceListValuationValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Price list name is required.")
                   .NotEmpty()
                   .WithMessage("Price list name is required.")
                   .MaximumLength(30)
                   .WithMessage("Price list name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(DoesPriceListExists)
                .WithMessage("Price list with given id does not exist.");
        }

        private async Task<bool> DoesPriceListExists(UpdatePriceListCommand command, CancellationToken cancellationToken)
        {
            var priceList = await _context.PriceLists
                                          .Where(p => p.IdPriceList == command.IdPriceList)
                                          .SingleOrDefaultAsync();

            return priceList != null;
        }
    }
}
