using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Queries.GetValuationQuery
{
    public class GetValuationQueryHandler : IRequestHandler<GetValuationQuery, Domain.Models.Valuation>
    {
        private readonly IApplicationContext _context;

        public GetValuationQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Valuation> Handle(GetValuationQuery request, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == request.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation;
        }
    }
}
