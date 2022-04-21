using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListBySupplyQuery
{
    public class GetDeliveriesAddressesListBySupplyValidator : AbstractValidator<GetDeliveriesAddressesListBySupplyQuery>
    {
        private readonly IApplicationContext _context;

        public GetDeliveriesAddressesListBySupplyValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesSupplyExists)
                .WithMessage("Supply with given id does not exist.");
        }

        private async Task<bool> DoesSupplyExists(GetDeliveriesAddressesListBySupplyQuery command, CancellationToken cancellationToken)
        {
            var supply = await _context.Supplies
                                       .Where(p => p.IdSupply == command.IdSupply)
                                       .SingleOrDefaultAsync();

            return supply != null;
        }
    }
}
