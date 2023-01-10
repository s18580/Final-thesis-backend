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

            RuleFor(p => p).
                MustAsync(DoesRelationsExists)
                .WithMessage("Binding type is still related with some order items.");
        }

        private async Task<bool> DoesBindingTypeExists(DeleteBindingTypeCommand command, CancellationToken cancellationToken)
        {
            var bindingType = await _context.BindingTypes
                                            .Where(p => p.IdBindingType == command.IdBindingType)
                                            .SingleOrDefaultAsync();

            return bindingType != null;
        }

        private async Task<bool> DoesRelationsExists(DeleteBindingTypeCommand command, CancellationToken cancellationToken)
        {
            var orders = await _context.OrderItems
                                     .Where(p => p.IdBindingType == command.IdBindingType)
                                     .ToListAsync();

            var valuations = await _context.Valuations
                                     .Where(p => p.IdBindingType == command.IdBindingType)
                                     .ToListAsync();

            return (orders.Count == 0 && valuations.Count == 0);
        }
    }
}
