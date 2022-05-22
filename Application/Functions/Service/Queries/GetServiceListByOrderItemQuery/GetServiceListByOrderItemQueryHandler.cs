using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Queries.GetServiceListByOrderItemQuery
{
    public class GetServiceListByOrderItemQueryHandler : IRequestHandler<GetServiceListByOrderItemQuery, GetServiceListByOrderItemResponse>
    {
        private readonly IApplicationContext _context;

        public GetServiceListByOrderItemQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetServiceListByOrderItemResponse> Handle(GetServiceListByOrderItemQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetServiceListByOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetServiceListByOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var services = await _context.Services
                                         .Where(p => p.IdOrderItem == request.IdOrderItem)
                                         .ToListAsync();

            return new GetServiceListByOrderItemResponse(services);
        }
    }
}
