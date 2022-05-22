using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Queries.GetColorListByValuationQuery
{
    public class GetColorListByValuationQueryHandler : IRequestHandler<GetColorListByValuationQuery, GetColorListByValuationResponse>
    {
        private readonly IApplicationContext _context;

        public GetColorListByValuationQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetColorListByValuationResponse> Handle(GetColorListByValuationQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetColorListByValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetColorListByValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var colors = await _context.Colors
                                       .Where(p => p.IdValuation == request.IdValuation)
                                       .ToListAsync();

            return new GetColorListByValuationResponse(colors);
        }
    }
}
