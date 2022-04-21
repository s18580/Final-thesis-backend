using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Queries.GetOrderItemListQuery
{
    public class GetOrderItemListQueryHandler : IRequestHandler<GetOrderItemListQuery, List<Domain.Models.OrderItem>>
    {
        private readonly IApplicationContext _context;

        public GetOrderItemListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.OrderItem>> Handle(GetOrderItemListQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _context.OrderItems
                                           .ToListAsync();

            return orderItems;
        }
    }
}
