using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.SupplyItemType.Commands.DeleteSupplyItemTypeCommand
{
    public class DeleteSupplyItemTypeValidator : AbstractValidator<DeleteSupplyItemTypeCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteSupplyItemTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesSupplyItemTypeExists)
                .WithMessage("Supply item type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesSupplyExists)
                .WithMessage("Supply item type is still related with some supplies.");
        }

        private async Task<bool> DoesSupplyItemTypeExists(DeleteSupplyItemTypeCommand command, CancellationToken cancellationToken)
        {
            var supplyItemType = await _context.SupplyItemTypes
                                     .Where(p => p.IdSupplyItemType == command.IdSupplyItemType)
                                     .SingleOrDefaultAsync();

            return supplyItemType != null;
        }

        private async Task<bool> DoesSupplyExists(DeleteSupplyItemTypeCommand command, CancellationToken cancellationToken)
        {
            var supplies = await _context.Supplies
                                         .Where(p => p.IdSupplyItemType == command.IdSupplyItemType)
                                         .ToListAsync();

            return supplies.Count == 0;
        }
    }
}
