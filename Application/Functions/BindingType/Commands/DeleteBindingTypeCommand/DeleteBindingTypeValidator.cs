using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.BindingType.Commands.DeleteBindingTypeCommand
{
    public class DeleteBindingTypeValidator : AbstractValidator<DeleteBindingTypeCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteBindingTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesBindingTypeExists)
                .WithMessage("Binding type with given id does not exist.");
        }

        private async Task<bool> DoesBindingTypeExists(DeleteBindingTypeCommand command, CancellationToken cancellationToken)
        {
            var bindingType = await _context.BindingTypes
                                            .Where(p => p.IdBindingType == command.IdBindingType)
                                            .SingleOrDefaultAsync();

            return bindingType != null;
        }
    }
}
