using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Queries.GetAddressListByOwnerIdQuery
{
    public class GetAddressListByOwnerIdQueryHandler : IRequestHandler<GetAddressListByOwnerIdQuery, GetAddressListByOwnerIdResponse>
    {
        private readonly IApplicationContext _context;

        public GetAddressListByOwnerIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetAddressListByOwnerIdResponse> Handle(GetAddressListByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAddressListByOwnerIdValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetAddressListByOwnerIdResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var addresses = await _context.Addresses
                                          .Where(p => p.IdOwner == request.IdOwner)
                                          .ToListAsync();

            return new GetAddressListByOwnerIdResponse(addresses);
        }
    }
}
