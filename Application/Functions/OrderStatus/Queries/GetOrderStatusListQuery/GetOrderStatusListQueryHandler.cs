using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderStatus.Queries.GetOrderStatusListQuery
{
    public class GetOrderStatusListQueryHandler : IRequestHandler<GetOrderStatusListQuery, List<Domain.Models.DictionaryModels.OrderStatus>>
    {
        private readonly IApplicationContext _context;

        public GetOrderStatusListQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<List<Domain.Models.DictionaryModels.OrderStatus>> Handle(GetOrderStatusListQuery request, CancellationToken cancellationToken)
        {
            var orderStatuses = await _context.OrderStatuses
                                              .ToListAsync();

            return orderStatuses;
        }
    }
}
