using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Worksites.Commands.DeleteWorksite
{
    public class DeleteWorksiteValidator : AbstractValidator<DeleteWorksiteCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteWorksiteValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesWorksiteExists)
                .WithMessage("Worksite with given id does not exist");
        }

        private async Task<bool> DoesWorksiteExists(DeleteWorksiteCommand command, CancellationToken cancellationToken)
        {
            var worksite = await _context.Worksites
                                       .Where(p => p.IdWorksite == command.Id)
                                       .SingleOrDefaultAsync();

            return worksite != null;
        }
    }
}
