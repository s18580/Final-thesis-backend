using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetCustomerActiveRepresentativesListQuery
{
    public class GetCustomerActiveRepresentativesListQueryHandler : IRequestHandler<GetCustomerActiveRepresentativesListQuery, List<Domain.Models.Representative>>
    {
        private readonly IApplicationContext _context;

        public GetCustomerActiveRepresentativesListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Representative>> Handle(GetCustomerActiveRepresentativesListQuery request, CancellationToken cancellationToken)
        {
            var representatives = await _context.Representatives
                                                .Where(p => p.IdCustomer == request.Id && p.IsDisabled == false)
                                                .ToListAsync();

            return representatives;
        }
    }
}
