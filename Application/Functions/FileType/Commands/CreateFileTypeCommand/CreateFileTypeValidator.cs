using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileType.Commands.CreateFileTypeCommand
{
    public class CreateFileTypeValidator : AbstractValidator<CreateFileTypeCommand>
    {
        private readonly IApplicationContext _context;

        public CreateFileTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("File type item type name is required.")
                   .NotEmpty()
                   .WithMessage("File type item type name is required.")
                   .MaximumLength(30)
                   .WithMessage("File type item type name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsFileTypeNameUnique)
                .WithMessage("File type item type with the same name already exist.");
        }

        private async Task<bool> IsFileTypeNameUnique(CreateFileTypeCommand command, CancellationToken cancellationToken)
        {
            var fileType = await _context.FileTypes
                                         .Where(x => x.Name == command.Name)
                                         .SingleOrDefaultAsync();

            return fileType == null;
        }
    }
}
