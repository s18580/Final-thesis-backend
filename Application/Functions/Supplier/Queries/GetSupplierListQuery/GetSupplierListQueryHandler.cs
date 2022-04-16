using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supplier.Queries.GetSupplierListQuery
{
    public class GetSupplierListQueryHandler : IRequestHandler<GetSupplierListQuery, List<Domain.Models.Supplier>>
    {
        private readonly IApplicationContext _context;

        public GetSupplierListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Supplier>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _context.Suppliers
                                          .ToListAsync();

            return suppliers;
        }
    }
}
