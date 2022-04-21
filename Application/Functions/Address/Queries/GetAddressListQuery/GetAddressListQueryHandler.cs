using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Queries.GetAddressListQuery
{
    public class GetAddressListQueryHandler : IRequestHandler<GetAddressListQuery, List<Domain.Models.Address>>
    {
        private readonly IApplicationContext _context;

        public GetAddressListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Address>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _context.Addresses
                                          .ToListAsync();

            return addresses;
        }
    }
}
