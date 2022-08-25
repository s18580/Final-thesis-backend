using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetRepresentativeListByCustomerQuery
{
    public class GetRepresentativeListByCustomerQueryHandler : IRequestHandler<GetRepresentativeListByCustomerQuery, GetRepresentativeListByCustomerResponse>
    {
        private readonly IApplicationContext _context;

        public GetRepresentativeListByCustomerQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetRepresentativeListByCustomerResponse> Handle(GetRepresentativeListByCustomerQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetRepresentativeListByCustomerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetRepresentativeListByCustomerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var representatives = await _context.Representatives
                                                .Where(p => p.IdCustomer == request.CustomerId)
                                                .ToListAsync();

            return new GetRepresentativeListByCustomerResponse(representatives);
        }
    }
}
