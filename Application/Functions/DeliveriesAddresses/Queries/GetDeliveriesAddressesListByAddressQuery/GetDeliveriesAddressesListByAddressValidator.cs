using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByAddressQuery
{
    public class GetDeliveriesAddressesListByAddressValidator : AbstractValidator<GetDeliveriesAddressesListByAddressQuery>
    {
        private readonly IApplicationContext _context;

        public GetDeliveriesAddressesListByAddressValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesAddressExists)
                .WithMessage("Address with given id does not exist.");
        }

        private async Task<bool> DoesAddressExists(GetDeliveriesAddressesListByAddressQuery command, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses
                                        .Where(p => p.IdAddress == command.IdAddress)
                                        .SingleOrDefaultAsync();

            return address != null;
        }
    }
}
