using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileType.Commands.DeleteFileTypeCommand
{
    public class DeleteFileTypeValidator : AbstractValidator<DeleteFileTypeCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteFileTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesFileTypeExists)
                .WithMessage("File type with given id does not exist.");
        }

        private async Task<bool> DoesFileTypeExists(DeleteFileTypeCommand command, CancellationToken cancellationToken)
        {
            var fileType = await _context.FileTypes
                                         .Where(p => p.IdFileType == command.IdFileType)
                                         .SingleOrDefaultAsync();

            return fileType != null;
        }
    }
}
