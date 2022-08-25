using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetRepresentativeListByCustomerQuery
{
    public class GetRepresentativeListByCustomerValidator : AbstractValidator<GetRepresentativeListByCustomerQuery>
    {
        private readonly IApplicationContext _context;

        public GetRepresentativeListByCustomerValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesCustomerExists)
                .WithMessage("Customer with given id does not exist.");
        }

        private async Task<bool> DoesCustomerExists(GetRepresentativeListByCustomerQuery command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                                         .Where(p => p.IdCustomer == command.CustomerId)
                                         .SingleOrDefaultAsync();

            return customer != null;
        }
    }
}
