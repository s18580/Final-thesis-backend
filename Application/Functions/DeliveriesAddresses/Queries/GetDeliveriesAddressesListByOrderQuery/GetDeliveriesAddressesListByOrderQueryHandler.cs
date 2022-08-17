using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByOrderQuery
{
    public class GetDeliveriesAddressesListByOrderQueryHandler : IRequestHandler<GetDeliveriesAddressesListByOrderQuery, GetDeliveriesAddressesListByOrderResponse>
    {
        private readonly IApplicationContext _context;

        public GetDeliveriesAddressesListByOrderQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetDeliveriesAddressesListByOrderResponse> Handle(GetDeliveriesAddressesListByOrderQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDeliveriesAddressesListByOrderValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetDeliveriesAddressesListByOrderResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var deliveriesAddresses = await _context.DeliveriesAddresses
                                                    .Include(m => m.Address)
                                                    .Where(p => p.IdOrder == request.IdOrder)
                                                    .ToListAsync();

            return new GetDeliveriesAddressesListByOrderResponse(deliveriesAddresses);
        }
    }
}
