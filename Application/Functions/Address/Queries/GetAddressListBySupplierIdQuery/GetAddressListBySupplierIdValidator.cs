using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Queries.GetAddressListBySupplierIdQuery
{
    public class GetAddressListBySupplierIdValidator : AbstractValidator<GetAddressListBySupplierIdQuery>
    {
        private readonly IApplicationContext _context;

        public GetAddressListBySupplierIdValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesSupplierExists)
                .WithMessage("Supplier with given id does not exists.");
        }

        private async Task<bool> DoesSupplierExists(GetAddressListBySupplierIdQuery command, CancellationToken cancellationToken)
        {
            var supplier = await _context.Addresses
                                         .Where(p => p.IdSupplier == command.IdSupplier)
                                         .SingleOrDefaultAsync();

            return supplier != null;
        }
    }
}
