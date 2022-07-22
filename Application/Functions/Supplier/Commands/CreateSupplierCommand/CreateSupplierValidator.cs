using Application.Services;
using FluentValidation;

namespace Application.Functions.Supplier.Commands.CreateSupplierCommand
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierCommand>
    {
        private readonly IApplicationContext _context;

        public CreateSupplierValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Supplier name is required.")
                   .NotEmpty()
                   .WithMessage("Supplier name is required.")
                   .MaximumLength(255)
                   .WithMessage("Supplier name length can't be longer then 255 characters.");

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
        }
    }
}
