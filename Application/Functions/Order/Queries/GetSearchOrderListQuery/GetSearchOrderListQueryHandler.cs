using Application.Functions.DTOs.SearchersDTOs;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetSearchOrderListQuery
{
    public class GetSearchOrderListQueryHandler : IRequestHandler<GetSearchOrderListQuery, List<SearchOrderDTO>>
    {
        private readonly IApplicationContext _context;

        public GetSearchOrderListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SearchOrderDTO>> Handle(GetSearchOrderListQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Models.Order> orders = new List<Domain.Models.Order>();
            if (request.Name.Equals("null") && request.Identifier.Equals("null") && request.ExpectedDeliveryDate.Equals("null") && request.Status.Equals("null") && request.CustomerRepresentativeName.Equals("null") && request.SupplierRepresentativeName.Equals("null") && request.WorkerName.Equals("null") && request.OrderItemType.Equals("null"))
            {
                orders = await _context.Orders
                                       .Include(m => m.Status)
                                       .Include(m => m.Representative)
                                       .Include(m => m.Assignments)
                                       .ThenInclude(m => m.Worker)
                                       .Include(m => m.OrderItems)
                                       .ThenInclude(m => m.OrderItemType)
                                       .ToListAsync();
            }
            else
            {
                var dateToCheck = DateTime.Parse(request.ExpectedDeliveryDate);
                orders = await _context.Orders
                                       .Include(m => m.Status)
                                       .Include(m => m.Representative)
                                       .Include(m => m.Assignments)
                                       .ThenInclude(m => m.Worker)
                                       .Include(m => m.OrderItems)
                                       .ThenInclude(m => m.OrderItemType)
                                       .Where(p => p.Name == request.Name || p.Identifier == request.Identifier || p.ExpectedDeliveryDate == dateToCheck || p.Status.Name == request.Status ||
                                              p.Assignments.Where(p => (p.Worker.Name + " " + p.Worker.LastName) == request.WorkerName).Count() > 0 || (p.Representative.Name + " " + p.Representative.LastName) == request.CustomerRepresentativeName || p.OrderItems.Where(p => p.OrderItemType.Name == request.OrderItemType).Count() > 0 || p.OrderItems.Where(p => p.Supplies.Where(p => (p.Representative.Name + " " + p.Representative.LastName) == request.SupplierRepresentativeName).Count() > 0).Count() > 0)
                                       .ToListAsync();
            }

            var ordersDTO = new List<SearchOrderDTO>();
            foreach (Domain.Models.Order order in orders)
            {
                var workersName = "";
                var orderItemTypes = "";

                foreach(var assignment in order.Assignments)
                {
                    workersName = workersName + assignment.Worker.Name + " " + assignment.Worker.LastName + ", ";
                }

                foreach (var orderItem in order.OrderItems)
                {
                    orderItemTypes = orderItemTypes + orderItem.OrderItemType.Name + ", ";
                }

                var orderDTO = new SearchOrderDTO
                {
                    IdOrder = order.IdOrder,
                    Name = order.Name,
                    Identifier = order.Identifier,
                    DeliveryDate = order.ExpectedDeliveryDate.ToString(),
                    OrderStatus = order.Status.Name,
                    RepresentativeName = order.Representative.Name + " " + order.Representative.LastName,
                    Workers = workersName,
                    OrderItemTypes = orderItemTypes,
                    IsAuction = order.IsAuction
                };

                ordersDTO.Add(orderDTO);
            }

            return ordersDTO;
        }
    }
}
