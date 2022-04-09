using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Worksites.Commands.UpdateWorksite
{
    public class UpdateWorksiteValidator : AbstractValidator<UpdateWorksiteCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateWorksiteValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Worksite name is required.")
                   .NotEmpty()
                   .WithMessage("Worksite name is required.")
                   .MaximumLength(30)
                   .WithMessage("Worksite name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsWorksiteNameUnique)
                .WithMessage("Worksite with the same name already exist");

            RuleFor(p => p).
                MustAsync(IsWorksiteExists)
                .WithMessage("Worksite with given id does not exist");
        }

        private async Task<bool> IsWorksiteNameUnique(UpdateWorksiteCommand command, CancellationToken cancellationToken)
        {
            var worksite = await _context.Worksites
                                         .Where(x => x.Name == command.Name)
                                         .SingleOrDefaultAsync();

            return worksite == null;
        }

        private async Task<bool> IsWorksiteExists(UpdateWorksiteCommand command, CancellationToken cancellationToken)
        {
            var worksite = await _context.Worksites
                                         .Where(p => p.IdWorksite == command.Id)
                                         .SingleOrDefaultAsync();

            return worksite != null;
        }
    }
}
