using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Commands.DeleteWorker
{
    public class DeleteWorkerValidator : AbstractValidator<DeleteWorkerCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteWorkerValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given id does not exist");

            RuleFor(p => p).
                MustAsync(IsWorkerDisabled)
                .WithMessage("The worker must be disabled before deleting");
        }

        private async Task<bool> DoesWorkerExists(DeleteWorkerCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                     .Where(p => p.IdWorker == command.Id)
                                     .SingleOrDefaultAsync();

            return worker != null;
        }

        private async Task<bool> IsWorkerDisabled(DeleteWorkerCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                     .Where(p => p.IdWorker == command.Id)
                                     .Where(p => p.IsDisabled == true)
                                     .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
