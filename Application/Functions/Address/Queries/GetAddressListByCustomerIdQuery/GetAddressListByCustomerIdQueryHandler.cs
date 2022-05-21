using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Queries.GetAddressListByCustomerIdQuery
{
    public class GetAddressListByCustomerIdQueryHandler : IRequestHandler<GetAddressListByCustomerIdQuery, GetAddressListByCustomerIdResponse>
    {
        private readonly IApplicationContext _context;

        public GetAddressListByCustomerIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetAddressListByCustomerIdResponse> Handle(GetAddressListByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAddressListByCustomerIdValidator (_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetAddressListByCustomerIdResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var addresses = await _context.Addresses
                                          .Where(p => p.IdCustomer == request.IdCustomer)
                                          .ToListAsync();

            return new GetAddressListByCustomerIdResponse(addresses);
        }
    }
}
