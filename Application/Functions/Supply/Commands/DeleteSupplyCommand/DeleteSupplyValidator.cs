using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Commands.DeleteSupplyCommand
{
    public class DeleteSupplyValidator : AbstractValidator<DeleteSupplyCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteSupplyValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesSupplyExists)
                .WithMessage("Supply with given id does not exist.");
        }
        private async Task<bool> DoesSupplyExists(DeleteSupplyCommand command, CancellationToken cancellationToken)
        {
            var supply = await _context.Supplies
                                       .Where(p => p.IdSupply == command.IdSupply)
                                       .SingleOrDefaultAsync();

            return supply != null;
        }
    }
}
