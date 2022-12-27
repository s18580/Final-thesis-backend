using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DTOs.DTOsValidators
{
    public class WorkerAssignmentDTOValidator : AbstractValidator<WorkerAssignmentDTO>
    {
        private readonly IApplicationContext _context;

        public WorkerAssignmentDTOValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given does not exist.");
        }

        private async Task<bool> DoesWorkerExists(WorkerAssignmentDTO command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.IdWorker == command.IdWorker)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
