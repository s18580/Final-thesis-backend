using Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOrderListByWorkerQuery
{
    public class GetOrderListByWorkerQueryHandler : IRequestHandler<GetOrderListByWorkerQuery, GetOrderListByWorkerResponse>
    {
        private readonly IApplicationContext _context;

        public GetOrderListByWorkerQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetOrderListByWorkerResponse> Handle(GetOrderListByWorkerQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOrderListByWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetOrderListByWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var rawOrders = await _context.Orders
                                          .Include(b => b.Assignments.Where(p => p.IdWorker == request.IdWorker).Where(p => p.OrderLeader == true))
                                          .Include(b => b.OrderItems)
                                          .Include(b => b.Status)
                                          .ToListAsync();

            var orders = new List<TableOrderListDTO>();

            foreach(var order in rawOrders)
            {
                var orderItemNames = new List<string>();
                foreach (var orderItem in order.OrderItems)
                {
                    orderItemNames.Add(orderItem.Name);
                }

                var newOrder = new TableOrderListDTO()
                {
                    IdOrder = order.IdOrder,
                    Identifier = order.Identifier,
                    Name = order.Name,
                    CreationDate = order.CreationDate.ToString("dd/MM/yyyy"),
                    IsAuction = order.IsAuction,
                    StatusName = order.Status.Name,
                    StatusColor = order.Status.ChipColor,
                    OrderItemsNames = orderItemNames
                };

                orders.Add(newOrder);
            }

            return new GetOrderListByWorkerResponse(orders);
        }
    }
}
