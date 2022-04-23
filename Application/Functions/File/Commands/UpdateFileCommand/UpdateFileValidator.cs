using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Commands.UpdateFileCommand
{
    public class UpdateFileValidator : AbstractValidator<UpdateFileCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateFileValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("File name is required.")
                   .NotEmpty()
                   .WithMessage("File name is required.")
                   .MaximumLength(50)
                   .WithMessage("File name length can't be longer then 50 characters.");

            RuleFor(p => p).
                MustAsync(DoesFileExists)
                .WithMessage("File with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesFileStatusExists)
                .WithMessage("File status with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesFileTypeExists)
                .WithMessage("File type with given id does not exist.");
        }

        private async Task<bool> DoesFileExists(UpdateFileCommand command, CancellationToken cancellationToken)
        {
            var file = await _context.Files
                                      .Where(p => p.IdFile == command.IdFile)
                                      .SingleOrDefaultAsync();

            return file != null;
        }

        private async Task<bool> DoesFileStatusExists(UpdateFileCommand command, CancellationToken cancellationToken)
        {
            var fileStatus = await _context.FileStatuses
                                           .Where(p => p.IdFileStatus == command.IdFileStatus)
                                           .SingleOrDefaultAsync();

            return fileStatus != null;
        }

        private async Task<bool> DoesFileTypeExists(UpdateFileCommand command, CancellationToken cancellationToken)
        {
            var fileType = await _context.FileTypes
                                         .Where(p => p.IdFileType == command.IdFileType)
                                         .SingleOrDefaultAsync();

            return fileType != null;
        }
    }
}
