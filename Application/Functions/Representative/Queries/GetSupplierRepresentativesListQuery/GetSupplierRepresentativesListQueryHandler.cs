using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetSupplierRepresentativesListQuery
{
    public class GetSupplierRepresentativesListQueryHandler : IRequestHandler<GetSupplierRepresentativesListQuery, List<Domain.Models.Representative>>
    {
        private readonly IApplicationContext _context;

        public GetSupplierRepresentativesListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Representative>> Handle(GetSupplierRepresentativesListQuery request, CancellationToken cancellationToken)
        {
            var representatives = await _context.Representatives
                                                .Where(p => p.IdSupplier != null)
                                                .ToListAsync();

            return representatives;
        }
    }
}
