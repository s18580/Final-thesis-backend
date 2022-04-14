using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveryType.Queries.GetDeliveryTypeQuery
{
    public class GetDeliveryTypeQueryHandler : IRequestHandler<GetDeliveryTypeQuery, Domain.Models.DictionaryModels.DeliveryType>
    {
        private readonly IApplicationContext _context;

        public GetDeliveryTypeQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DictionaryModels.DeliveryType> Handle(GetDeliveryTypeQuery request, CancellationToken cancellationToken)
        {
            var deliveryType = await _context.DeliveryTypes
                                               .Where(p => p.IdDeliveryType == request.IdDeliveryType)
                                               .SingleOrDefaultAsync();

            return deliveryType;
        }
    }
}
