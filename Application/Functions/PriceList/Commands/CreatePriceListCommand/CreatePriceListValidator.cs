using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.PriceList.Commands.CreatePriceListCommand
{
    public class CreatePriceListValidator : AbstractValidator<CreatePriceListCommand>
    {
        private readonly IApplicationContext _context;

        public CreatePriceListValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Price list name is required.")
                   .NotEmpty()
                   .WithMessage("Price list name is required.")
                   .MaximumLength(30)
                   .WithMessage("Price list name length can't be longer then 30 characters.");
        }
    }
}
