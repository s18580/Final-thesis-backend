using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileStatus.Commands.DeleteFileStatusCommand
{
    public class DeleteFileStatusValidator : AbstractValidator<DeleteFileStatusCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteFileStatusValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesFileStatusExists)
                .WithMessage("File status with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesFilesWithStatusesExists)
                .WithMessage("File status is still related with some files.");
        }

        private async Task<bool> DoesFileStatusExists(DeleteFileStatusCommand command, CancellationToken cancellationToken)
        {
            var fileStatus = await _context.FileStatuses
                                            .Where(p => p.IdFileStatus == command.IdFileStatus)
                                            .SingleOrDefaultAsync();

            return fileStatus != null;
        }

        private async Task<bool> DoesFilesWithStatusesExists(DeleteFileStatusCommand command, CancellationToken cancellationToken)
        {
            var filesWithStatuses = await _context.Files
                                      .Where(p => p.IdFileStatus == command.IdFileStatus)
                                      .ToListAsync();

            return filesWithStatuses.Count == 0;
        }
    }
}
