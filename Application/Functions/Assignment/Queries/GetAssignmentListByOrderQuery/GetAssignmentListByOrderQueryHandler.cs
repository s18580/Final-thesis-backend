using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Queries.GetAssignmentListByOrderQuery
{
    public class GetAssignmentListByOrderQueryHandler : IRequestHandler<GetAssignmentListByOrderQuery, GetAssignmentListByOrderResponse>
    {
        private readonly IApplicationContext _context;
        public GetAssignmentListByOrderQueryHandler(IApplicationContext context)
        {
            _context = context;

        }
        public async Task<GetAssignmentListByOrderResponse> Handle(GetAssignmentListByOrderQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAssignmentListByOrderValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetAssignmentListByOrderResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var assignments = await _context.Assignments
                                            .Where(p => p.IdOrder == request.IdOrder)
                                            .ToListAsync();

            return new GetAssignmentListByOrderResponse(assignments);
        }
    }
}
