using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItemType.Queries.GetOrderItemTypeQuery
{
    public class GetOrderItemTypeQueryHandler : IRequestHandler<GetOrderItemTypeQuery, Domain.Models.DictionaryModels.OrderItemType>
    {
        private readonly IApplicationContext _context;

        public GetOrderItemTypeQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DictionaryModels.OrderItemType> Handle(GetOrderItemTypeQuery request, CancellationToken cancellationToken)
        {
            var orderItemType = await _context.OrderItemTypes
                                               .Where(p => p.IdOrderItemType == request.IdOrderItemType)
                                               .SingleOrDefaultAsync();

            return orderItemType;
        }
    }
}
