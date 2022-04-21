using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Queries.GetAddressListByOwnerIdQuery
{
    public class GetAddressListByOwnerIdValidator : AbstractValidator<GetAddressListByOwnerIdQuery>
    {
        private readonly IApplicationContext _context;

        public GetAddressListByOwnerIdValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOwnerExists)
                .WithMessage("Owner with given id does not exists.");
        }

        private async Task<bool> DoesOwnerExists(GetAddressListByOwnerIdQuery command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                                               .Where(p => p.IdCustomer == command.IdOwner)
                                               .SingleOrDefaultAsync();

            var supplier = await _context.Suppliers
                                               .Where(p => p.IdSupplier == command.IdOwner)
                                               .SingleOrDefaultAsync();

            return (customer != null || supplier != null);
        }
    }
}
