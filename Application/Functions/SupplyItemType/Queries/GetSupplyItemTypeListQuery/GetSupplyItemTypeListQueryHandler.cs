using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.SupplyItemType.Queries.GetSupplyItemTypeListQuery
{
    public class GetSupplyItemTypeListQueryHandler : IRequestHandler<GetSupplyItemTypeListQuery, List<Domain.Models.DictionaryModels.SupplyItemType>>
    {
        private readonly IApplicationContext _context;

        public GetSupplyItemTypeListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DictionaryModels.SupplyItemType>> Handle(GetSupplyItemTypeListQuery request, CancellationToken cancellationToken)
        {
            var supplyItemTypes = await _context.SupplyItemTypes
                                                .ToListAsync();

            return supplyItemTypes;
        }
    }
}
