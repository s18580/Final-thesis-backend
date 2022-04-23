using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Commands.DeletePaperCommand
{
    public class DeletePaperValidator : AbstractValidator<DeletePaperCommand>
    {
        private readonly IApplicationContext _context;

        public DeletePaperValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesPaperExists)
                .WithMessage("Paper with given id does not exist.");
        }

        private async Task<bool> DoesPaperExists(DeletePaperCommand command, CancellationToken cancellationToken)
        {
            var paper = await _context.Papers
                                      .Where(p => p.IdPaper == command.IdPaper)
                                      .SingleOrDefaultAsync();

            return paper != null;
        }
    }
}
