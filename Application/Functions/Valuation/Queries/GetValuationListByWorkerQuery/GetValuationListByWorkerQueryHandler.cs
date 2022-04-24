using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Queries.GetValuationListByWorkerQuery
{
    public class GetValuationListByWorkerQueryHandler : IRequestHandler<GetValuationListByWorkerQuery, GetValuationListByWorkerResponse>
    {
        private readonly IApplicationContext _context;

        public GetValuationListByWorkerQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetValuationListByWorkerResponse> Handle(GetValuationListByWorkerQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetValuationListByWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetValuationListByWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var valuations = await _context.Valuations
                                           .Where(p => p.IdAuthor == request.IdWorker)
                                           .ToListAsync();

            return new GetValuationListByWorkerResponse(valuations);
        }
    }
}
