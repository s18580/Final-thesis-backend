using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListBySupplyQuery
{
    public class GetDeliveriesAddressesListBySupplyQueryHandler : IRequestHandler<GetDeliveriesAddressesListBySupplyQuery, GetDeliveriesAddressesListBySupplyResponse>
    {
        private readonly IApplicationContext _context;

        public GetDeliveriesAddressesListBySupplyQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetDeliveriesAddressesListBySupplyResponse> Handle(GetDeliveriesAddressesListBySupplyQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDeliveriesAddressesListBySupplyValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetDeliveriesAddressesListBySupplyResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var deliveriesAddresses = await _context.DeliveriesAddresses
                                                    .Where(p => p.IdSupply == request.IdSupply)
                                                    .ToListAsync();

            return new GetDeliveriesAddressesListBySupplyResponse(deliveriesAddresses);
        }
    }
}
