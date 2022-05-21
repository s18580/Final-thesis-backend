using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Queries.GetAddressListBySupplierIdQuery
{
    public class GetAddressListBySupplierIdQueryHandler : IRequestHandler<GetAddressListBySupplierIdQuery, GetAddressListBySupplierIdResponse>
    {
        private readonly IApplicationContext _context;

        public GetAddressListBySupplierIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetAddressListBySupplierIdResponse> Handle(GetAddressListBySupplierIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAddressListBySupplierIdValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetAddressListBySupplierIdResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var addresses = await _context.Addresses
                                          .Where(p => p.IdSupplier == request.IdSupplier)
                                          .ToListAsync();

            return new GetAddressListBySupplierIdResponse(addresses);
        }
    }
}
