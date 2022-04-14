using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileStatus.Commands.CreateFileStatusCommand
{
    public class CreateFileStatusValidator : AbstractValidator<CreateFileStatusCommand>
    {
        private readonly IApplicationContext _context;

        public CreateFileStatusValidator(IApplicationContext context)
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
                .WithMessage("File status with the same name already exist");
        }

        private async Task<bool> IsFileStatusNameUnique(CreateFileStatusCommand command, CancellationToken cancellationToken)
        {
            var fileStatus = await _context.FileStatuses
                                           .Where(x => x.Name == command.Name)
                                           .SingleOrDefaultAsync();

            return fileStatus == null;
        }
    }
}
