using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Commands.CreateAddressCommand
{
    public class CreateAddressValidator : AbstractValidator<CreateAddressCommand>
    {
        private readonly IApplicationContext _context;

        public CreateAddressValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
               MustAsync(DoesLinkIsGiven)
               .WithMessage("Specyfic link was not given.");

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Address name is required.")
                   .NotEmpty()
                   .WithMessage("Address name is required.")
                   .MaximumLength(100)
                   .WithMessage("Address name length can't be longer then 100 characters.");

            RuleFor(p => p.Country)
                   .NotNull()
                   .WithMessage("Country is required.")
                   .NotEmpty()
                   .WithMessage("Country is required.")
                   .MaximumLength(30)
                   .WithMessage("Country length can't be longer then 30 characters.");

            RuleFor(p => p.City)
                   .NotNull()
                   .WithMessage("City is required.")
                   .NotEmpty()
                   .WithMessage("City is required.")
                   .MaximumLength(50)
                   .WithMessage("City length can't be longer then 50 characters.");

            RuleFor(p => p.PostCode)
                   .NotNull()
                   .WithMessage("Post code can't be null.")
                   .MaximumLength(11)
                   .WithMessage("Post code length can't be longer then 11 characters.");

            RuleFor(p => p.StreetName)
                   .NotNull()
                   .WithMessage("Street name is required.")
                   .NotEmpty()
                   .WithMessage("Street name is required.")
                   .MaximumLength(100)
                   .WithMessage("Street name length can't be longer then 100 characters.");

            RuleFor(p => p.StreetNumber)
                   .NotNull()
                   .WithMessage("Street number is required.")
                   .NotEmpty()
                   .WithMessage("Street number is required.")
                   .MaximumLength(10)
                   .WithMessage("Street number length can't be longer then 10 characters.");

            RuleFor(p => p.ApartmentNumber)
                   .NotNull()
                   .WithMessage("Apartment number can't be null.")
                   .MaximumLength(10)
                   .WithMessage("Apartment number length can't be longer then 10 characters.");

            RuleFor(p => p).
                MustAsync(DoesOwnerExists)
                .WithMessage("Owner with given id does not exists.");
        }

        private async Task<bool> DoesOwnerExists(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                                               .Where(p => p.IdCustomer == command.IdCustomer)
                                               .SingleOrDefaultAsync();

            var supplier = await _context.Suppliers
                                               .Where(p => p.IdSupplier == command.IdSupplier)
                                               .SingleOrDefaultAsync();

            return (customer != null || supplier != null);
        }

        private async Task<bool> DoesLinkIsGiven(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            return !(command.IdCustomer != null && command.IdSupplier != null) || !(command.IdCustomer == null && command.IdSupplier == null);
        }
    }
}
