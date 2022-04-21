using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.BindingType.Commands.CreateBindingTypeCommand
{
    public class CreateBindingTypeValidator : AbstractValidator<CreateBindingTypeCommand>
    {
        private readonly IApplicationContext _context;

        public CreateBindingTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Binding type name is required.")
                   .NotEmpty()
                   .WithMessage("Binding type name is required.")
                   .MaximumLength(30)
                   .WithMessage("Binding type name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsBindingTypeNameUnique)
                .WithMessage("Binding type with the same name already exist");
        }

        private async Task<bool> IsBindingTypeNameUnique(CreateBindingTypeCommand command, CancellationToken cancellationToken)
        {
            var bindingType = await _context.BindingTypes
                                           .Where(x => x.Name == command.Name)
                                           .SingleOrDefaultAsync();

            return bindingType == null;
        }
    }
}
