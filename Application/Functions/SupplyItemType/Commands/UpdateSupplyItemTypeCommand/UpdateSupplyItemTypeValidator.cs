using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.SupplyItemType.Commands.UpdateSupplyItemTypeCommand
{
    public class UpdateSupplyItemTypeValidator : AbstractValidator<UpdateSupplyItemTypeCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateSupplyItemTypeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Supply item type name is required.")
                   .NotEmpty()
                   .WithMessage("Supply item type name is required.")
                   .MaximumLength(30)
                   .WithMessage("Supply item type name length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsSupplyItemTypeNameUnique)
                .WithMessage("Supply item type with the same name already exist");

            RuleFor(p => p).
                MustAsync(DoesSupplyItemTypeExists)
                .WithMessage("Supply item type with given id does not exist");
        }

        private async Task<bool> IsSupplyItemTypeNameUnique(UpdateSupplyItemTypeCommand command, CancellationToken cancellationToken)
        {
            var supplyItemType = await _context.SupplyItemTypes
                                         .Where(x => x.Name == command.Name)
                                         .SingleOrDefaultAsync();

            return supplyItemType == null;
        }

        private async Task<bool> DoesSupplyItemTypeExists(UpdateSupplyItemTypeCommand command, CancellationToken cancellationToken)
        {
            var supplyItemType = await _context.SupplyItemTypes
                                         .Where(p => p.IdSupplyItemType == command.IdSupplyItemType)
                                         .SingleOrDefaultAsync();

            return supplyItemType != null;
        }
    }
}
