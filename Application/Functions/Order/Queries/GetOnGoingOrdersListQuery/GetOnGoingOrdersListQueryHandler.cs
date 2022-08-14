using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOnGoingOrdersListQuery
{
    public class GetOnGoingOrdersListQueryHandler : IRequestHandler<GetOnGoingOrdersListQuery, List<TableOnGoingOrdersDTO>>
    {
        private readonly IApplicationContext _context;

        public GetOnGoingOrdersListQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<List<TableOnGoingOrdersDTO>> Handle(GetOnGoingOrdersListQuery request, CancellationToken cancellationToken)
        {
            var rawOrders = await _context.Orders
                                          .Include(b => b.OrderItems)
                                          .Include(b => b.Status)
                                          .Where(p => p.Status.Name != "Dostarczone")
                                          .OrderBy(p => p.ExpectedDeliveryDate)
                                          .ToListAsync();

            var orders = new List<TableOnGoingOrdersDTO>();

            foreach (var order in rawOrders)
            {
                var orderItemNames = new List<string>();
                foreach (var orderItem in order.OrderItems)
                {
                    orderItemNames.Add(orderItem.Name);
                }

                var newOrder = new TableOnGoingOrdersDTO()
                {
                    IdOrder = order.IdOrder,
                    Identifier = order.Identifier,
                    Name = order.Name,
                    CreationDate = order.CreationDate.ToString("dd/MM/yyyy"),
                    ExpectedDeliveryDate = order.ExpectedDeliveryDate.HasValue ? order.ExpectedDeliveryDate.Value.ToString("dd/MM/yyyy") : "-",
                    IsAuction = order.IsAuction,
                    StatusName = order.Status.Name,
                    StatusColor = order.Status.ChipColor,
                    OrderItemsNames = orderItemNames
                };

                orders.Add(newOrder);
            }


            return orders;
        }
    }
}
