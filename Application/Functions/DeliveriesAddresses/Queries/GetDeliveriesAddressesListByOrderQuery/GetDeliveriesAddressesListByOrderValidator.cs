using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByOrderQuery
{
    public class GetDeliveriesAddressesListByOrderValidator : AbstractValidator<GetDeliveriesAddressesListByOrderQuery>
    {
        private readonly IApplicationContext _context;

        public GetDeliveriesAddressesListByOrderValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderExists)
                .WithMessage("Order with given id does not exist.");
        }

        private async Task<bool> DoesOrderExists(GetDeliveriesAddressesListByOrderQuery command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                                      .Where(p => p.IdOrder == command.IdOrder)
                                      .SingleOrDefaultAsync();

            return order != null;
        }
    }
}
