using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Queries.GetOrderItemQuery
{
    public class GetOrderItemQueryHandler : IRequestHandler<GetOrderItemQuery, Domain.Models.OrderItem>
    {
        private readonly IApplicationContext _context;

        public GetOrderItemQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.OrderItem> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Include(p => p.BindingType)
                                          .Include(p => p.Colors)
                                          .Include(p => p.Papers)
                                          .Include(p => p.OrderItemType)
                                          .Include(p => p.DeliveryType)
                                          .Include(p => p.Services)
                                          .ThenInclude(p => p.ServiceName)
                                          .Where(p => p.IdOrderItem == request.IdOrderItem)
                                          .SingleOrDefaultAsync();

            return orderItem;
        }
    }
}
