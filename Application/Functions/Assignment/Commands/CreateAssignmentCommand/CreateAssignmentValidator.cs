using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Commands.CreateAssignmentCommand
{
    public class CreateAssignmentValidator : AbstractValidator<CreateAssignmentCommand>
    {
        private readonly IApplicationContext _context;

        public CreateAssignmentValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesAssignmentExists)
                .WithMessage("Assignment with given ids already exist.");

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given ids already exist.");

            RuleFor(p => p).
                MustAsync(DoesOrderExists)
                .WithMessage("Order with given ids already exist.");
        }

        private async Task<bool> DoesAssignmentExists(CreateAssignmentCommand command, CancellationToken cancellationToken)
        {
            var assignment = await _context.Assignments
                                           .Where(p => p.IdOrder == command.IdOrder)
                                           .Where(p => p.IdWorker == command.IdWorker)
                                           .SingleOrDefaultAsync();

            return assignment == null;
        }

        private async Task<bool> DoesWorkerExists(CreateAssignmentCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.IdWorker == command.IdWorker)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }

        private async Task<bool> DoesOrderExists(CreateAssignmentCommand command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                                      .Where(p => p.IdOrder == command.IdOrder)
                                      .SingleOrDefaultAsync();

            return order != null;
        }
    }
}
