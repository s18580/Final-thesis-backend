using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOrderListByDeliveryDateQuery
{
    public class GetOrderListByDeliveryDateQueryHandler : IRequestHandler<GetOrderListByDeliveryDateQuery, List<TableOrderListClosestDTO>>
    {
        private readonly IApplicationContext _context;

        public GetOrderListByDeliveryDateQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<List<TableOrderListClosestDTO>> Handle(GetOrderListByDeliveryDateQuery request, CancellationToken cancellationToken)
        {
            var rawOrders = await _context.Orders
                                       .Include(b => b.OrderItems)
                                       .Include(b => b.Status)
                                       .OrderBy(p => p.ExpectedDeliveryDate)
                                       .ToListAsync();

            var orders = new List<TableOrderListClosestDTO>();

            foreach (var order in rawOrders)
            {
                var orderItemNames = new List<string>();
                foreach (var orderItem in order.OrderItems)
                {
                    orderItemNames.Add(orderItem.Name);
                }

                var newOrder = new TableOrderListClosestDTO()
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
