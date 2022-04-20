using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Queries.GetAssignmentListByWorkerQuery
{
    public class GetAssignmentListByWorkerQueryHandler : IRequestHandler<GetAssignmentListByWorkerQuery, GetAssignmentListByWorkerResponse>
    {
        private readonly IApplicationContext _context;
        public GetAssignmentListByWorkerQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetAssignmentListByWorkerResponse> Handle(GetAssignmentListByWorkerQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAssignmentListByWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetAssignmentListByWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var assignments = await _context.Assignments
                                            .Where(p => p.IdWorker == request.IdWorker)
                                            .ToListAsync();

            return new GetAssignmentListByWorkerResponse(assignments);
        }
    }
}
