using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Queries.GetOrderItemListByOrderIdQuery
{
    public class GetOrderItemListByOrderIdQueryHandler : IRequestHandler<GetOrderItemListByOrderIdQuery, GetOrderItemListByOrderIdResponse>
    {
        private readonly IApplicationContext _context;

        public GetOrderItemListByOrderIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetOrderItemListByOrderIdResponse> Handle(GetOrderItemListByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOrderItemListByOrderIdValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetOrderItemListByOrderIdResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var orderItems = await _context.OrderItems
                                           .Include(m => m.Papers)
                                           .Include(m => m.Colors)
                                           .Include(m => m.Supplies)
                                           .Include(m => m.Valuations)
                                           .Include(m => m.Services)
                                           .ThenInclude(m => m.ServiceName)
                                           .Where(p => p.IdOrder == request.IdOrder)
                                           .ToListAsync();

            return new GetOrderItemListByOrderIdResponse(orderItems);
        }
    }
}
