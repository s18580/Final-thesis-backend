using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.PriceList.Queries.GetPriceListQuery
{
    public class GetPriceListQueryHandler : IRequestHandler<GetPriceListQuery, Domain.Models.DictionaryModels.PriceList>
    {
        private readonly IApplicationContext _context;
        public GetPriceListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DictionaryModels.PriceList> Handle(GetPriceListQuery request, CancellationToken cancellationToken)
        {
            var priceList = await _context.PriceLists
                                          .Where(p => p.IdPriceList == request.IdPriceList)
                                          .SingleOrDefaultAsync();

            return priceList;
        }
    }
}
