using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Queries.GetPaperListByValuationQuery
{
    public class GetPaperListByValuationQueryHandler : IRequestHandler<GetPaperListByValuationQuery, GetPaperListByValuationResponse>
    {
        private readonly IApplicationContext _context;

        public GetPaperListByValuationQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetPaperListByValuationResponse> Handle(GetPaperListByValuationQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetPaperListByValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetPaperListByValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var papers = await _context.Papers
                                       .Where(p => p.IdLink == request.IdValuation)
                                       .ToListAsync();

            return new GetPaperListByValuationResponse(papers);
        }
    }
}
