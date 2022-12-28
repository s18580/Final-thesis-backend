using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetSupplierActiveRepresentativesListQuery
{
    public class GetSupplierActiveRepresentativesListQueryHandler : IRequestHandler<GetSupplierActiveRepresentativesListQuery, List<Domain.Models.Representative>>
    {
        private readonly IApplicationContext _context;

        public GetSupplierActiveRepresentativesListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Representative>> Handle(GetSupplierActiveRepresentativesListQuery request, CancellationToken cancellationToken)
        {
            var representatives = await _context.Representatives
                                                .Where(p => p.IdSupplier == request.Id && p.IsDisabled == false)
                                                .ToListAsync();

            return representatives;
        }
    }
}
