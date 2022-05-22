using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesQuery
{
    public class GetDeliveriesAddressesQueryHandler : IRequestHandler<GetDeliveriesAddressesQuery, Domain.Models.DeliveriesAddresses>
    {
        private readonly IApplicationContext _context;

        public GetDeliveriesAddressesQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DeliveriesAddresses> Handle(GetDeliveriesAddressesQuery request, CancellationToken cancellationToken)
        {
            var deliveriesAddresses = await _context.DeliveriesAddresses
                                                    .Where(p => p.IdDeliveriesAddresses == request.IdDeliveriesAddresses)
                                                    .SingleOrDefaultAsync();

            return deliveriesAddresses;
        }
    }
}
