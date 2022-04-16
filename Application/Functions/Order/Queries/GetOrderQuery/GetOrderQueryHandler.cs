using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOrderQuery
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Domain.Models.Order>
    {
        private readonly IApplicationContext _context;

        public GetOrderQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                                      .Where(p => p.IdOrder == request.IdOrder)
                                      .SingleOrDefaultAsync();

            return order;
        }
    }
}
