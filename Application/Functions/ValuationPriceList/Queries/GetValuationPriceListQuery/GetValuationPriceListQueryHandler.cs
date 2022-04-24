using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListQuery
{
    public class GetValuationPriceListQueryHandler : IRequestHandler<GetValuationPriceListQuery, Domain.Models.ValuationPriceList>
    {
        private readonly IApplicationContext _context;

        public GetValuationPriceListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.ValuationPriceList> Handle(GetValuationPriceListQuery request, CancellationToken cancellationToken)
        {
            var valuationPriceList = await _context.ValuationPriceLists
                                                   .Where(p => p.IdValuation == request.IdValuation)
                                                   .Where(p => p.IdPriceList == request.IdPriceList)
                                                   .SingleOrDefaultAsync();

            return valuationPriceList;
        }
    }
}
