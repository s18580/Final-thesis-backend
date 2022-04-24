using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByValuationQuery
{
    public class GetValuationPriceListListByValuationQueryHandler : IRequestHandler<GetValuationPriceListListByValuationQuery, GetValuationPriceListListByValuationResponse>
    {
        private readonly IApplicationContext _context;

        public GetValuationPriceListListByValuationQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetValuationPriceListListByValuationResponse> Handle(GetValuationPriceListListByValuationQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetValuationPriceListListByValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetValuationPriceListListByValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var valuationPriceLists = await _context.ValuationPriceLists
                                                    .Where(p => p.IdValuation == request.IdValuation)
                                                    .ToListAsync();

            return new GetValuationPriceListListByValuationResponse(valuationPriceLists);
        }
    }
}
