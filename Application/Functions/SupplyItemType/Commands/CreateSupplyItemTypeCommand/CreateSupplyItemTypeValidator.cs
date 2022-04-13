using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand
{
    public class CreateSupplyItemTypeValidator : AbstractValidator<CreateSupplyItemTypeCommand>
    {
        private readonly IApplicationContext _context;

        public CreateSupplyItemTypeValidator(IApplicationContext context)
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
        }

        private async Task<bool> IsSupplyItemTypeNameUnique(CreateSupplyItemTypeCommand command, CancellationToken cancellationToken)
        {
            var role = await _context.SupplyItemTypes
                                     .Where(x => x.Name == command.Name)
                                     .SingleOrDefaultAsync();

            return role == null;
        }
    }
}
