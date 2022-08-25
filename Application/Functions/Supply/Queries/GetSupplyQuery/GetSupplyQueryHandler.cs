using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Queries.GetSupplyQuery
{
    public class GetSupplyQueryHandler : IRequestHandler<GetSupplyQuery, Domain.Models.Supply>
    {
        private readonly IApplicationContext _context;

        public GetSupplyQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<Domain.Models.Supply> Handle(GetSupplyQuery request, CancellationToken cancellationToken)
        {
            var supply = await _context.Supplies
                                       .Include(p => p.SupplyItemType.Name)
                                       .Include(p => p.OrderItem)
                                       .ThenInclude(p => p.Order.Name)
                                       .Include(p => p.Representative.IdSupplier)
                                       .Where(p => p.IdSupply == request.IdSupply)
                                       .SingleOrDefaultAsync();

            return supply;
        }
    }
}
