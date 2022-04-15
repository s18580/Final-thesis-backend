using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Queries.GetCustomerQuery
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Domain.Models.Customer>
    {
        private readonly IApplicationContext _context;

        public GetCustomerQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                                         .Where(p => p.IdCustomer == request.IdCustomer)
                                         .SingleOrDefaultAsync();

            return customer;
        }
    }
}
