using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Commands.CreatePersonCustomerCommand
{
    public class CreatePersonCustomerValidator : AbstractValidator<CreatePersonCustomerCommand>
    {
        private readonly IApplicationContext _context;

        public CreatePersonCustomerValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.CompanyName)
                   .NotNull()
                   .WithMessage("Company name is required.")
                   .NotEmpty()
                   .WithMessage("Company name is required.")
                   .MaximumLength(255)
                   .WithMessage("Company name length can't be longer then 255 characters.");

            RuleFor(p => p.CompanyEmailAddress)
                   .NotNull()
                   .WithMessage("Company email address is required.")
                   .NotEmpty()
                   .WithMessage("Company email address is required.")
                   .MaximumLength(255)
                   .WithMessage("Company email address length can't be longer then 255 characters.")
                   .EmailAddress()
                   .WithMessage("Email format is not correct.");

            RuleFor(p => p.CompanyPhoneNumber)
                   .NotNull()
                   .WithMessage("Company phone number is required.")
                   .NotEmpty()
                   .WithMessage("Company phone number is required.")
                   .MaximumLength(32)
                   .WithMessage("Company phone number length can't be longer then 32 characters.");

            RuleFor(p => p).
                MustAsync(IsCompanyEmailAddressUnique)
                .WithMessage("Customer with same company email address already exist.");

            RuleFor(p => p).
                MustAsync(CheckIfWorkerExists)
                .WithMessage("Worker with given id does not exists.");
        }

        private async Task<bool> IsCompanyEmailAddressUnique(CreatePersonCustomerCommand command, CancellationToken cancellationToken)
        {
            var email = await _context.Customers
                                      .Where(x => x.CompanyEmailAddress == command.CompanyEmailAddress)
                                      .SingleOrDefaultAsync();

            return email == null;
        }

        private async Task<bool> CheckIfWorkerExists(CreatePersonCustomerCommand command, CancellationToken cancellationToken)
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
