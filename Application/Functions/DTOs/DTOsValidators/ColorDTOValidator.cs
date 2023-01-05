using FluentValidation;

namespace Application.Functions.DTOs.DTOsValidators
{
    public class ColorDTOValidator : AbstractValidator<ColorDTO>
    {
        public ColorDTOValidator()
        {
            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Color name is required.")
                   .NotEmpty()
                   .WithMessage("Color name is required.")
                   .MaximumLength(10)
                   .WithMessage("Color name length can't be longer then 10 characters.");
        }
    }
}