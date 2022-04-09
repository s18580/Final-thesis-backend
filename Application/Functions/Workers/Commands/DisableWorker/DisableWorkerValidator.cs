using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Commands.DisableWorker
{
    public class DisableWorkerValidator : AbstractValidator<DisableWorkerCommand>
    {
        private readonly IApplicationContext _context;

        public DisableWorkerValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(IsWorkerExists)
                .WithMessage("Worker with given id does not exist");
        }

        private async Task<bool> IsWorkerExists(DisableWorkerCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.IdWorker == command.Id)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
