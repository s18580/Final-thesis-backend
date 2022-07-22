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

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Name is required.")
                   .NotEmpty()
                   .WithMessage("Name is required.")
                   .MaximumLength(32)
                   .WithMessage("Name length can't be longer then 32 characters.");

            RuleFor(p => p.LastName)
                   .NotNull()
                   .WithMessage("Last name is required.")
                   .NotEmpty()
                   .WithMessage("Last name is required.")
                   .MaximumLength(64)
                   .WithMessage("Last name length can't be longer then 64 characters.");

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

        private async Task<bool> IsCompanyEmailAddressUnique(CreatePersonCustomerCommand command, CancellationToken cancellationToken)
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
