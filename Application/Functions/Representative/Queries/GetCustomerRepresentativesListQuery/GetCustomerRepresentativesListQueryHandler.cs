using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetCustomerRepresentativesListQuery
{
    public class GetCustomerRepresentativesListQueryHandler : IRequestHandler<GetCustomerRepresentativesListQuery, List<Domain.Models.Representative>>
    {
        private readonly IApplicationContext _context;

        public GetCustomerRepresentativesListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Representative>> Handle(GetCustomerRepresentativesListQuery request, CancellationToken cancellationToken)
        {
            var representatives = await _context.Representatives
                                                .Where(p => p.IdCustomer != null)
                                                .ToListAsync();

            return representatives;
        }
    }
}
