using FluentValidation;

namespace Application.Functions.DTOs.DTOsValidators
{
    public  class RepresentativeDTOValidator : AbstractValidator<RepresentativeDTO>
    {
        public RepresentativeDTOValidator()
        {;
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
        }
    }
}
