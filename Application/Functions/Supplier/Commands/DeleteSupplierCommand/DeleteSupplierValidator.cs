using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supplier.Commands.DeleteSupplierCommand
{
    public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteSupplierValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesSupplierExists)
                .WithMessage("Supplier with given id does not exists.");
        }

        private async Task<bool> DoesSupplierExists(DeleteSupplierCommand command, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers
                                         .Where(x => x.IdSupplier == command.IdSupplier)
                                         .SingleOrDefaultAsync();

            return supplier != null;
        }
    }
}
