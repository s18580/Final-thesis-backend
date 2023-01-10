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

            RuleFor(p => p).
                MustAsync(DoesLinkIsGiven)
                .WithMessage("Specyfic link was not given.");

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("Representative name is required.")
                  .NotEmpty()
                  .WithMessage("Representative name is required.")
                  .MaximumLength(32)
                  .WithMessage("Representative name length can't be longer then 32 characters.");

            RuleFor(p => p.LastName)
                  .NotNull()
                  .WithMessage("Representative last name is required.")
                  .NotEmpty()
                  .WithMessage("Representative last name is required.")
                  .MaximumLength(64)
                  .WithMessage("Representative last name length can't be longer then 64 characters.");

            RuleFor(p => p.PhoneNumber)
                   .NotNull()
                   .WithMessage("Phone number can't be null.")
                   .MaximumLength(32)
                   .WithMessage("Phone number length can't be longer then 32 characters.");

            RuleFor(p => p.EmailAddress)
                   .NotNull()
                   .WithMessage("Email address can't be null.")
                   .MaximumLength(255)
                   .WithMessage("Email address length can't be longer then 255 characters.");

            RuleFor(p => p).
                MustAsync(DoesOwnerExists)
                .WithMessage("Owner with given id does not exist.");
        }

        private async Task<bool> DoesOwnerExists(CreateRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                                               .Where(p => p.IdCustomer == command.IdCustomer)
                                               .SingleOrDefaultAsync();

            var supplier = await _context.Suppliers
                                               .Where(p => p.IdSupplier == command.IdSupplier)
                                               .SingleOrDefaultAsync();

            return (customer != null || supplier != null);
        }

        private async Task<bool> DoesLinkIsGiven(CreateRepresentativeCommand command, CancellationToken cancellationToken)
        {
            return !(command.IdCustomer != null && command.IdSupplier != null) || !(command.IdCustomer == null && command.IdSupplier == null);
        }
    }
}
