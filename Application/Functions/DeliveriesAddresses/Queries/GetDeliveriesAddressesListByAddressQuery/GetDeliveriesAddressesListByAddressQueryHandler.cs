using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByAddressQuery
{
    public class GetDeliveriesAddressesListByAddressQueryHandler : IRequestHandler<GetDeliveriesAddressesListByAddressQuery, GetDeliveriesAddressesListByAddressResponse>
    {
        private readonly IApplicationContext _context;

        public GetDeliveriesAddressesListByAddressQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetDeliveriesAddressesListByAddressResponse> Handle(GetDeliveriesAddressesListByAddressQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDeliveriesAddressesListByAddressValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetDeliveriesAddressesListByAddressResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var deliveriesAddresses = await _context.DeliveriesAddresses
                                                    .Where(p => p.IdAddress == request.IdAddress)
                                                    .ToListAsync();

            return new GetDeliveriesAddressesListByAddressResponse(deliveriesAddresses);
        }
    }
}
