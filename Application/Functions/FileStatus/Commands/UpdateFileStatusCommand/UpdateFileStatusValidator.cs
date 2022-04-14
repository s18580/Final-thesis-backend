using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileStatus.Commands.UpdateFileStatusCommand
{
    public class UpdateFileStatusValidator : AbstractValidator<UpdateFileStatusCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateFileStatusValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("File status name is required.")
                  .NotEmpty()
                  .WithMessage("File status name is required.")
                  .MaximumLength(30)
                  .WithMessage("File status name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsFileStatusNameUnique)
                .WithMessage("File status with the same name already exist.");

            RuleFor(p => p).
                MustAsync(DoesFileStatusExists)
                .WithMessage("File status with given id does not exist.");
        }

        private async Task<bool> IsFileStatusNameUnique(UpdateFileStatusCommand command, CancellationToken cancellationToken)
        {
            var fileStatus = await _context.FileStatuses
                                           .Where(x => x.Name == command.Name)
                                           .SingleOrDefaultAsync();

            return fileStatus == null;
        }

        private async Task<bool> DoesFileStatusExists(UpdateFileStatusCommand command, CancellationToken cancellationToken)
        {
            var fileStatus = await _context.FileStatuses
                                           .Where(p => p.IdFileStatus == command.IdFileStatus)
                                           .SingleOrDefaultAsync();

            return fileStatus != null;
        }
    }
}
