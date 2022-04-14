using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderStatus.Queries.GetOrderStatusQuery
{
    public class GetOrderStatusQueryHandler : IRequestHandler<GetOrderStatusQuery, Domain.Models.DictionaryModels.OrderStatus>
    {
        private readonly IApplicationContext _context;

        public GetOrderStatusQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DictionaryModels.OrderStatus> Handle(GetOrderStatusQuery request, CancellationToken cancellationToken)
        {
            var orderStatus = await _context.OrderStatuses
                                               .Where(p => p.IdStatus == request.IdOrderStatus)
                                               .SingleOrDefaultAsync();

            return orderStatus;
        }
    }
}
