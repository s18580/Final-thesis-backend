using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Queries.GetServiceListByValuationQuery
{
    public class GetServiceListByValuationQueryHandler : IRequestHandler<GetServiceListByValuationQuery, GetServiceListByValuationResponse>
    {
        private readonly IApplicationContext _context;

        public GetServiceListByValuationQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetServiceListByValuationResponse> Handle(GetServiceListByValuationQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetServiceListByValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetServiceListByValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var services = await _context.Services
                                         .Where(p => p.IdLink == request.IdValuation)
                                         .ToListAsync();

            return new GetServiceListByValuationResponse(services);
        }
    }
}
