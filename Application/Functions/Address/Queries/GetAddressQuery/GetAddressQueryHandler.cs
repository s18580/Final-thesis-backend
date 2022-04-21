using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Queries.GetAddressQuery
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Domain.Models.Address>
    {
        private readonly IApplicationContext _context;

        public GetAddressQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Address> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses
                                        .Where(p => p.IdAddress == request.IdAddress)
                                        .SingleOrDefaultAsync();

            return address;
        }
    }
}
