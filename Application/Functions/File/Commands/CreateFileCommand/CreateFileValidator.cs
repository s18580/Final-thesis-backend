using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Commands.CreateFileCommand
{
    public class CreateFileValidator : AbstractValidator<CreateFileCommand>
    {
        private readonly IApplicationContext _context;

        public CreateFileValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesLinkIsGiven)
                .WithMessage("Specyfic link was not given.");

            RuleFor(p => p.FileKey)
                   .NotNull()
                   .WithMessage("File name is required.")
                   .NotEmpty()
                   .WithMessage("File name is required.")
                   .MaximumLength(200)
                   .WithMessage("File name length can't be longer then 200 characters.");

            RuleFor(p => p).
                MustAsync(DoesFileStatusExists)
                .WithMessage("File status with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesFileTypeExists)
                .WithMessage("File type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesLinkExists)
                .WithMessage("Link with given id does not exist.");
        }

        private async Task<bool> DoesFileStatusExists(CreateFileCommand command, CancellationToken cancellationToken)
        {
            var fileStatus = await _context.FileStatuses
                                           .Where(p => p.IdFileStatus == command.IdFileStatus)
                                           .SingleOrDefaultAsync();

            return fileStatus != null;
        }

        private async Task<bool> DoesFileTypeExists(CreateFileCommand command, CancellationToken cancellationToken)
        {
            var fileType = await _context.FileTypes
                                         .Where(p => p.IdFileType == command.IdFileType)
                                         .SingleOrDefaultAsync();

            return fileType != null;
        }

        private async Task<bool> DoesLinkExists(CreateFileCommand command, CancellationToken cancellationToken)
        {
            var valutaion = await _context.Valuations
                                               .Where(p => p.IdValuation == command.IdValuation)
                                               .SingleOrDefaultAsync();

            var order = await _context.Orders
                                      .Where(p => p.IdOrder == command.IdOrder)
                                      .SingleOrDefaultAsync();

            return (valutaion != null || order != null);
        }

        private async Task<bool> DoesLinkIsGiven(CreateFileCommand command, CancellationToken cancellationToken)
        {
            return !(command.IdOrder != null && command.IdValuation == null) ||
                !(command.IdOrder != null && command.IdValuation == null) ||
                !(command.IdOrder != null && command.IdValuation != null) ||
                !(command.IdOrder == null && command.IdValuation != null) ||
                !(command.IdOrder == null && command.IdValuation != null) ||
                !(command.IdOrder == null && command.IdValuation == null) ||
                !(command.IdOrder != null && command.IdValuation != null) ||
                !(command.IdOrder == null && command.IdValuation == null );
        }
    }
}
