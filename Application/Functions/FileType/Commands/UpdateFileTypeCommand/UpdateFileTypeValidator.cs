using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace Application.Functions.FileType.Commands.UpdateFileTypeCommand
{
    public class UpdateFileTypeValidator : AbstractValidator<UpdateFileTypeCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateFileTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("File type name is required.")
                  .NotEmpty()
                  .WithMessage("File type name is required.")
                  .MaximumLength(30)
                  .WithMessage("File type name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsFileTypeNameUnique)
                .WithMessage("File type with the same name already exist.");

            RuleFor(p => p).
                MustAsync(DoesFileTypeExists)
                .WithMessage("File type with given id does not exist.");
        }

        private async Task<bool> IsFileTypeNameUnique(UpdateFileTypeCommand command, CancellationToken cancellationToken)
        {
            var fileType = await _context.FileTypes
                                         .Where(x => x.Name == command.Name)
                                         .SingleOrDefaultAsync();

            return fileType == null;
        }

        private async Task<bool> DoesFileTypeExists(UpdateFileTypeCommand command, CancellationToken cancellationToken)
        {
            var fileType = await _context.FileTypes
                                         .Where(p => p.IdFileType == command.IdFileType)
                                         .SingleOrDefaultAsync();

            return fileType != null;
        }
    }
}
