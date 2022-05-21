using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Queries.GetPaperListByOrderItemQuery
{
    public class GetPaperListByOrderItemQueryHandler : IRequestHandler<GetPaperListByOrderItemQuery, GetPaperListByOrderItemResponse>
    {
        private readonly IApplicationContext _context;

        public GetPaperListByOrderItemQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetPaperListByOrderItemResponse> Handle(GetPaperListByOrderItemQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetPaperListByOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetPaperListByOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var papers = await _context.Papers
                                       .Where(p => p.IdOrderItem == request.IdOrderItem)
                                       .ToListAsync();

            return new GetPaperListByOrderItemResponse(papers);
        }
    }
}
