using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Queries.GetColorListByOrderItemQuery
{
    public class GetColorListByOrderItemQueryHandler : IRequestHandler<GetColorListByOrderItemQuery, GetColorListByOrderItemResponse>
    {
        private readonly IApplicationContext _context;

        public GetColorListByOrderItemQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetColorListByOrderItemResponse> Handle(GetColorListByOrderItemQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetColorListByOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetColorListByOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var colors = await _context.Colors
                                       .Where(p => p.IdOrderItem == request.IdOrderItem)
                                       .ToListAsync();

            return new GetColorListByOrderItemResponse(colors);
        }
    }
}
