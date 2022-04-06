using Application.Services;
using FluentValidation;

namespace Application.Functions.Worksites.Commands.CreateWorksite
{
    public class CreateWorksiteValidator : AbstractValidator<CreateWorksiteCommand>
    {
        private readonly IApplicationContext _context;

        public CreateWorksiteValidator(IApplicationContext context)
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
        }

        private async Task<bool> IsWorksiteNameUnique(CreateWorksiteCommand command, CancellationToken cancellationToken)
        {
            //ToDo
            //var result = await _context.IsWorksiteNameUnique(command.Name);
            return true;
        }
    }
}
