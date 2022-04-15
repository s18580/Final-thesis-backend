using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Queries.GetCustomerListQuery
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<Domain.Models.Customer>>
    {
        private readonly IApplicationContext _context;

        public GetCustomerListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers
                                          .ToListAsync();

            return customers;
        }
    }
}
