using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.SupplyItemType.Queries.GetSupplyItemTypeQuery
{
    public class GetSupplyItemTypeQueryHandler : IRequestHandler<GetSupplyItemTypeQuery, Domain.Models.DictionaryModels.SupplyItemType>
    {
        private readonly IApplicationContext _context;

        public GetSupplyItemTypeQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DictionaryModels.SupplyItemType> Handle(GetSupplyItemTypeQuery request, CancellationToken cancellationToken)
        {
            var supplyItemType = await _context.SupplyItemTypes
                                               .Where(p => p.IdSupplyItemType == request.IdSupplyItemType)
                                               .SingleOrDefaultAsync();

            return supplyItemType;
        }
    }
}
