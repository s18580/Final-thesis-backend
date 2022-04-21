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
                                          .Where(p => p.IdOrderItem == request.IdOrderItem)
                                          .SingleOrDefaultAsync();

            return orderItem;
        }
    }
}
