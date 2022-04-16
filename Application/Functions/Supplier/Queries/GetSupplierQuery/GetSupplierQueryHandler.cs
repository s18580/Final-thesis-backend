using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supplier.Queries.GetSupplierQuery
{
    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, Domain.Models.Supplier>
    {
        private readonly IApplicationContext _context;

        public GetSupplierQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Supplier> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _context.Suppliers
                                          .Where(p => p.IdSupplier == request.IdSupplier)
                                          .SingleOrDefaultAsync();

            return suppliers;
        }
    }
}
