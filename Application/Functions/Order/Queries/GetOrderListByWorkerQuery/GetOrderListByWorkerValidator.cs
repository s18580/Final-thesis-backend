using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOrderListByWorkerQuery
{
    public class GetOrderListByWorkerValidator : AbstractValidator<GetOrderListByWorkerQuery>
    {
        private readonly IApplicationContext _context;

        public GetOrderListByWorkerValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given id does not exist.");
        }

        private async Task<bool> DoesWorkerExists(GetOrderListByWorkerQuery command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                            .Where(p => p.IdWorker == command.IdWorker)
                                            .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
