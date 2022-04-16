using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOrderListQuery
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<Domain.Models.Order>>
    {
        private readonly IApplicationContext _context;

        public GetOrderListQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<List<Domain.Models.Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                                       .ToListAsync();

            return orders;
        }
    }
}
