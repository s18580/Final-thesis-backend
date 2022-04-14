using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveryType.Queries.GetDeliveryTypeListQuery
{
    public class GetDeliveryTypeListQueryHandler : IRequestHandler<GetDeliveryTypeListQuery, List<Domain.Models.DictionaryModels.DeliveryType>>
    {
        private readonly IApplicationContext _context;

        public GetDeliveryTypeListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DictionaryModels.DeliveryType>> Handle(GetDeliveryTypeListQuery request, CancellationToken cancellationToken)
        {
            var deliveryTypes = await _context.DeliveryTypes
                                              .ToListAsync();

            return deliveryTypes;
        }
    }
}
