using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetRepresentativeListBySupplierQuery
{
    public class GetRepresentativeListBySupplierValidator : AbstractValidator<GetRepresentativeListBySupplierQuery>
    {
        private readonly IApplicationContext _context;

        public GetRepresentativeListBySupplierValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesSupplierExists)
                .WithMessage("Supplier with given id does not exist.");
        }

        private async Task<bool> DoesSupplierExists(GetRepresentativeListBySupplierQuery command, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers
                                         .Where(p => p.IdSupplier == command.SupplierId)
                                         .SingleOrDefaultAsync();

            return supplier != null;
        }
    }
}
