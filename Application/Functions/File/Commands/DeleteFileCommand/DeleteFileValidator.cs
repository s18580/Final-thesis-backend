using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Commands.DeleteFileCommand
{
    public class DeleteFileValidator : AbstractValidator<DeleteFileCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteFileValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesFileExists)
                .WithMessage("File with given id does not exist.");
        }

        private async Task<bool> DoesFileExists(DeleteFileCommand command, CancellationToken cancellationToken)
        {
            var file = await _context.Files
                                     .Where(p => p.IdFile == command.IdFile)
                                     .SingleOrDefaultAsync();

            return file != null;
        }
    }
}
