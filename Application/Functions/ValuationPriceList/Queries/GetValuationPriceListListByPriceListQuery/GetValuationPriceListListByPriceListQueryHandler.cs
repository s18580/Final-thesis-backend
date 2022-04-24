using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByPriceListQuery
{
    public class GetValuationPriceListListByPriceListQueryHandler : IRequestHandler<GetValuationPriceListListByPriceListQuery, GetValuationPriceListListByPriceListResponse>
    {
        private readonly IApplicationContext _context;

        public GetValuationPriceListListByPriceListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetValuationPriceListListByPriceListResponse> Handle(GetValuationPriceListListByPriceListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetValuationPriceListListByPriceListValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetValuationPriceListListByPriceListResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var valuationPriceList = await _context.ValuationPriceLists
                                                   .Where(p => p.IdPriceList == request.IdPriceList)
                                                   .ToListAsync();

            return new GetValuationPriceListListByPriceListResponse(valuationPriceList);
        }
    }
}
