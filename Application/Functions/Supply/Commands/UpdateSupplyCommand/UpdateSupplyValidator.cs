using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Commands.UpdateSupplyCommand
{
    public class UpdateSupplyValidator : AbstractValidator<UpdateSupplyCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateSupplyValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.ItemDescription)
                  .NotNull()
                  .WithMessage("Item description is required.")
                  .NotEmpty()
                  .WithMessage("Item description is required.")
                  .MaximumLength(255)
                  .WithMessage("Item description length can't be longer then 255 characters.");

            RuleFor(p => p).
                MustAsync(DoesSupplyExists)
                .WithMessage("Supply with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesSupplyItemTypeExists)
                .WithMessage("Supply item type with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesRepresentativeExists)
                .WithMessage("Representative with given id does not exist.");
        }

        private async Task<bool> DoesSupplyItemTypeExists(UpdateSupplyCommand command, CancellationToken cancellationToken)
        {
            var supplyItemType = await _context.SupplyItemTypes
                                       .Where(p => p.IdSupplyItemType == command.IdSupplyItemType)
                                       .SingleOrDefaultAsync();

            return supplyItemType != null;
        }

        private async Task<bool> DoesSupplyExists(UpdateSupplyCommand command, CancellationToken cancellationToken)
        {
            var supply = await _context.Supplies
                                       .Where(p => p.IdSupply == command.IdSupply)
                                       .SingleOrDefaultAsync();

            return supply != null;
        }

        private async Task<bool> DoesRepresentativeExists(UpdateSupplyCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                       .Where(p => p.IdRepresentative == command.IdRepresentative)
                                       .SingleOrDefaultAsync();

            return representative != null;
        }
    }
}
