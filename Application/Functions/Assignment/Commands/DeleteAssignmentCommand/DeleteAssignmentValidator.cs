using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Commands.DeleteAssignmentCommand
{
    public class DeleteAssignmentValidator : AbstractValidator<DeleteAssignmentCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteAssignmentValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesAssignmentExists)
                .WithMessage("Assignment with given ids does not exist.");
        }

        private async Task<bool> DoesAssignmentExists(DeleteAssignmentCommand command, CancellationToken cancellationToken)
        {
            var assignment = await _context.Assignments
                                           .Where(p => p.IdOrder == command.IdOrder)
                                           .Where(p => p.IdWorker == command.IdWorker)
                                           .SingleOrDefaultAsync();

            return assignment != null;
        }
    }
}
