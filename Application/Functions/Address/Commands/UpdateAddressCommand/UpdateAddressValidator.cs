using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateAddressValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Address name is required.")
                   .NotEmpty()
                   .WithMessage("Address name is required.")
                   .MaximumLength(255)
                   .WithMessage("Address name length can't be longer then 255 characters.");

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
                   .MaximumLength(10)
                   .WithMessage("Post code length can't be longer then 10 characters.");

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
                   .WithMessage("Apartment number is required.")
                   .NotEmpty()
                   .WithMessage("Apartment number is required.")
                   .MaximumLength(10)
                   .WithMessage("Apartment number length can't be longer then 10 characters.");

            RuleFor(p => p).
                MustAsync(DoesAddressExists)
                .WithMessage("Address with given id does not exist.");
        }

        private async Task<bool> DoesAddressExists(UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses
                                        .Where(p => p.IdAddress == command.IdAddress)
                                        .SingleOrDefaultAsync();

            return address != null;
        }
    }
}
