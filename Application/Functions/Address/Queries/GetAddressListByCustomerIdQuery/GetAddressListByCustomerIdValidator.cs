using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Queries.GetAddressListByCustomerIdQuery
{
    public class GetAddressListByCustomerIdValidator : AbstractValidator<GetAddressListByCustomerIdQuery>
    {
        private readonly IApplicationContext _context;

        public GetAddressListByCustomerIdValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesCustomerExists)
                .WithMessage("Customer with given id does not exists.");
        }

        private async Task<bool> DoesCustomerExists(GetAddressListByCustomerIdQuery command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                                         .Where(p => p.IdCustomer == command.IdCustomer)
                                         .SingleOrDefaultAsync();

            return customer != null;
        }
    }
}
