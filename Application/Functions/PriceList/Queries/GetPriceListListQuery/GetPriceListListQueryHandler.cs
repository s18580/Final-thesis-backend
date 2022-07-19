using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.PriceList.Queries.GetPriceListListQuery
{
    public class GetPriceListListQueryHandler : IRequestHandler<GetPriceListListQuery, List<Domain.Models.DictionaryModels.PriceList>>
    {
        private readonly IApplicationContext _context;
        public GetPriceListListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DictionaryModels.PriceList>> Handle(GetPriceListListQuery request, CancellationToken cancellationToken)
        {
            var priceLists = await _context.PriceLists.ToListAsync();

            return priceLists;
        }
    }
}
