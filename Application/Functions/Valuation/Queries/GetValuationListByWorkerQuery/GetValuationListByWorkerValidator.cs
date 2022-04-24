using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Queries.GetValuationListByWorkerQuery
{
    public class GetValuationListByWorkerValidator : AbstractValidator<GetValuationListByWorkerQuery>
    {
        private readonly IApplicationContext _context;

        public GetValuationListByWorkerValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given id does not exist.");
        }

        private async Task<bool> DoesWorkerExists(GetValuationListByWorkerQuery command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.IdWorker == command.IdWorker)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
