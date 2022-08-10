using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Commands.CreateCompanyCustomerWithDataCommand
{
    public class CreateCompanyCustomerWithDataValidator : AbstractValidator<CreateCompanyCustomerWithDataCommand>
    {
        private readonly IApplicationContext _context;

        public CreateCompanyCustomerWithDataValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.CompanyName)
                   .NotNull()
                   .WithMessage("Company name is required.")
                   .NotEmpty()
                   .WithMessage("Company name is required.")
                   .MaximumLength(255)
                   .WithMessage("Company name length can't be longer then 255 characters.");

            RuleFor(p => p.NIP)
                   .NotNull()
                   .WithMessage("NIP is required.")
                   .NotEmpty()
                   .WithMessage("NIP is required.")
                   .MaximumLength(10)
                   .WithMessage("NIP length can't be longer then 10 characters.");

            RuleFor(p => p.Regon)
                   .NotNull()
                   .WithMessage("Regon is required.")
                   .NotEmpty()
                   .WithMessage("Regon is required.")
                   .MaximumLength(14)
                   .WithMessage("Regon length can't be longer then 14 characters.");

            RuleFor(p => p.CompanyEmailAddress)
                   .NotNull()
                   .WithMessage("Company email address can't be null.")
                   .MaximumLength(255)
                   .WithMessage("Company email address length can't be longer then 255 characters.");

            RuleFor(p => p.CompanyPhoneNumber)
                   .NotNull()
                   .WithMessage("Company phone number can't be null.")
                   .MaximumLength(32)
                   .WithMessage("Company phone number length can't be longer then 32 characters.");

            RuleFor(p => p).
                MustAsync(IsCompanyEmailAddressUnique)
                .WithMessage("Customer with same company email address already exist.");

            RuleFor(p => p).
                MustAsync(CheckIfWorkerExists)
                .WithMessage("Worker with given id does not exists.");
        }

        private async Task<bool> IsCompanyEmailAddressUnique(CreateCompanyCustomerWithDataCommand command, CancellationToken cancellationToken)
        {
            if (!command.CompanyEmailAddress.Equals(""))
            {
                var email = await _context.Customers
                                           .Where(x => x.CompanyEmailAddress == command.CompanyEmailAddress)
                                           .SingleOrDefaultAsync();

                return email == null;
            }

            return true;
        }

        private async Task<bool> CheckIfWorkerExists(CreateCompanyCustomerWithDataCommand command, CancellationToken cancellationToken)
        {
            if (command.IdWorker == null)
            {
                return true;
            }
            else
            {
                var worker = await _context.Workers
                                           .Where(x => x.IdWorker == command.IdWorker)
                                           .SingleOrDefaultAsync();

                return worker != null;
            }
        }
    }
}
