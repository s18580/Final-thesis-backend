using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOrderListByDeliveryDateQuery
{
    public class GetOrderListByDeliveryDateQueryHandler : IRequestHandler<GetOrderListByDeliveryDateQuery, List<Domain.Models.Order>>
    {
        private readonly IApplicationContext _context;

        public GetOrderListByDeliveryDateQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<List<Domain.Models.Order>> Handle(GetOrderListByDeliveryDateQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                                       .OrderBy(p => p.ExpectedDeliveryDate)
                                       .ToListAsync();

            return orders;
        }
    }
}
