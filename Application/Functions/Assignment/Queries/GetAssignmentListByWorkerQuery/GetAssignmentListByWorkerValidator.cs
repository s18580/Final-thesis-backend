using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Queries.GetAssignmentListByWorkerQuery
{
    public class GetAssignmentListByWorkerValidator : AbstractValidator<GetAssignmentListByWorkerQuery>
    {
        private readonly IApplicationContext _context;

        public GetAssignmentListByWorkerValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given ids already exist.");
        }

        private async Task<bool> DoesWorkerExists(GetAssignmentListByWorkerQuery command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.IdWorker == command.IdWorker)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
