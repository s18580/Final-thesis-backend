using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOrdersListByRepresentativeQuery
{
    public class GetOrdersListByRepresentativeQueryHandler : IRequestHandler<GetOrdersListByRepresentativeQuery, List<Domain.Models.Order>>
    {
        private readonly IApplicationContext _context;

        public GetOrdersListByRepresentativeQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Order>> Handle(GetOrdersListByRepresentativeQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                                       .Where(p => p.IdRepresentative == request.Id)
                                       .ToListAsync();

            return orders;
        }
    }
}
