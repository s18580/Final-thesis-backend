using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Queries.GetValuationListByOrderItemQuery
{
    public class GetValuationListByOrderItemQueryHandler : IRequestHandler<GetValuationListByOrderItemQuery, GetValuationListByOrderItemResponse>
    {
        private readonly IApplicationContext _context;

        public GetValuationListByOrderItemQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetValuationListByOrderItemResponse> Handle(GetValuationListByOrderItemQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetValuationListByOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetValuationListByOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var valuations = await _context.Valuations
                                           .Where(p => p.IdOrderItem == request.IdOrderItem)
                                           .ToListAsync();

            return new GetValuationListByOrderItemResponse(valuations);
        }
    }
}
