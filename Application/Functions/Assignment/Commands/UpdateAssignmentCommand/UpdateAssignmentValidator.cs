using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Commands.UpdateAssignmentCommand
{
    public class UpdateAssignmentValidator : AbstractValidator<UpdateAssignmentCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateAssignmentValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.HoursWorked)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Hours worked can't be less than 0.");

            RuleFor(p => p).
                MustAsync(DoesAssignmentExists)
                .WithMessage("Assignment with given ids does not exist.");
        }

        private async Task<bool> DoesAssignmentExists(UpdateAssignmentCommand command, CancellationToken cancellationToken)
        {
            var assignment = await _context.Assignments
                                           .Where(p => p.IdOrder == command.IdOrder)
                                           .Where(p => p.IdWorker == command.IdWorker)
                                           .SingleOrDefaultAsync();

            return assignment != null;
        }
    }
}
