using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItemType.Queries.GetOrderItemTypeListQuery
{
    public class GetOrderItemTypeListQueryHandler : IRequestHandler<GetOrderItemTypeListQuery, List<Domain.Models.DictionaryModels.OrderItemType>>
    {
        private readonly IApplicationContext _context;

        public GetOrderItemTypeListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DictionaryModels.OrderItemType>> Handle(GetOrderItemTypeListQuery request, CancellationToken cancellationToken)
        {
            var orderItemTypes = await _context.OrderItemTypes
                                                .ToListAsync();

            return orderItemTypes;
        }
    }
}
