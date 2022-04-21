using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.BindingType.Commands.UpdateBindingTypeCommand
{
    public class UpdateBindingTypeValidator : AbstractValidator<UpdateBindingTypeCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateBindingTypeValidator(IApplicationContext context)
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

            RuleFor(p => p).
                MustAsync(DoesBindingTypeExists)
                .WithMessage("Binding type with given id does not exist.");
        }

        private async Task<bool> IsBindingTypeNameUnique(UpdateBindingTypeCommand command, CancellationToken cancellationToken)
        {
            var bindingType = await _context.BindingTypes
                                            .Where(x => x.Name == command.Name)
                                            .SingleOrDefaultAsync();

            return bindingType == null;
        }

        private async Task<bool> DoesBindingTypeExists(UpdateBindingTypeCommand command, CancellationToken cancellationToken)
        {
            var bindingType = await _context.BindingTypes
                                            .Where(p => p.IdBindingType == command.IdBindingType)
                                            .SingleOrDefaultAsync();

            return bindingType != null;
        }
    }
}
