using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Queries.GetValuationListWithoutOrderItemQuery
{
    public class GetValuationListWithoutOrderItemQueryHandler : IRequestHandler<GetValuationListWithoutOrderItemQuery, List<Domain.Models.Valuation>>
    {
        private readonly IApplicationContext _context;

        public GetValuationListWithoutOrderItemQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Valuation>> Handle(GetValuationListWithoutOrderItemQuery request, CancellationToken cancellationToken)
        {
            var valuations = await _context.Valuations
                                           .Where(p => p.IdOrderItem == null)
                                           .ToListAsync();

            return valuations;
        }
    }
}
