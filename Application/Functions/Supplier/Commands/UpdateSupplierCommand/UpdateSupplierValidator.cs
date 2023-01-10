using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supplier.Commands.UpdateSupplierCommand
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateSupplierValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Supplier name is required.")
                   .NotEmpty()
                   .WithMessage("Supplier name is required.")
                   .MaximumLength(100)
                   .WithMessage("Supplier name length can't be longer then 100 characters.");

            RuleFor(p => p.EmailAddress)
                   .NotNull()
                   .WithMessage("Email address can't be null.")
                   .MaximumLength(255)
                   .WithMessage("Email address length can't be longer then 255 characters.");

            RuleFor(p => p.Description)
                   .MaximumLength(255)
                   .WithMessage("Description length can't be longer then 255 characters.");

            RuleFor(p => p.PhoneNumber)
                   .MaximumLength(32)
                   .WithMessage("Phone number length can't be longer then 32 characters.");

            RuleFor(p => p).
                MustAsync(DoesSupplierExists)
                .WithMessage("Supplier with given id does not exists.");
        }

        private async Task<bool> DoesSupplierExists(UpdateSupplierCommand command, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers
                                         .Where(x => x.IdSupplier == command.IdSupplier)
                                         .SingleOrDefaultAsync();

            return supplier != null;
        }
    }
}
