using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Commands.CreateRepresentativeCommand
{
    public class CreateRepresentativeValidator : AbstractValidator<CreateRepresentativeCommand>
    {
        private readonly IApplicationContext _context;

        public CreateRepresentativeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("Order status name is required.")
                  .NotEmpty()
                  .WithMessage("Order status name is required.")
                  .MaximumLength(32)
                  .WithMessage("Order status name length can't be longer then 32 characters.");

            RuleFor(p => p.LastName)
                  .NotNull()
                  .WithMessage("Order status name is required.")
                  .NotEmpty()
                  .WithMessage("Order status name is required.")
                  .MaximumLength(64)
                  .WithMessage("Order status name length can't be longer then 64 characters.");

            RuleFor(p => p.PhoneNumber)
                   .MaximumLength(32)
                   .WithMessage("Phone number length can't be longer then 32 characters.");

            RuleFor(p => p.EmailAddress)
                   .MaximumLength(255)
                   .WithMessage("Email address length can't be longer then 255 characters.")
                   .EmailAddress()
                   .WithMessage("Email format is not correct.");

            RuleFor(p => p).
                MustAsync(DoesOwnerExists)
                .WithMessage("Owner with given id does not exist.");
        }

        private async Task<bool> DoesOwnerExists(CreateRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                                               .Where(p => p.IdCustomer == command.IdOwner)
                                               .SingleOrDefaultAsync();

            var supplier = await _context.Suppliers
                                               .Where(p => p.IdSupplier == command.IdOwner)
                                               .SingleOrDefaultAsync();

            return (customer != null || supplier != null);
        }
    }
}
