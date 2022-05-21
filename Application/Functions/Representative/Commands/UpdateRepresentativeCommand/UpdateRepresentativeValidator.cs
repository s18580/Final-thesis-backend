using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Commands.UpdateRepresentativeCommand
{
    public class UpdateRepresentativeValidator : AbstractValidator<UpdateRepresentativeCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateRepresentativeValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("Order status name is required.")
                  .NotEmpty()
                  .WithMessage("Order status name is required.")
                  .MaximumLength(32)
                  .WithMessage("Order status name length can't be longer then 32 characters.");

            RuleFor(p => p.LastName)
                  .NotNull()
                  .WithMessage("Order status name is required.")
                  .NotEmpty()
                  .WithMessage("Order status name is required.")
                  .MaximumLength(64)
                  .WithMessage("Order status name length can't be longer then 64 characters.");

            RuleFor(p => p.PhoneNumber)
                   .MaximumLength(32)
                   .WithMessage("Phone number length can't be longer then 32 characters.");

            RuleFor(p => p.EmailAddress)
                   .MaximumLength(255)
                   .WithMessage("Email address length can't be longer then 255 characters.")
                   .EmailAddress()
                   .WithMessage("Email format is not correct.");

            RuleFor(p => p).
                MustAsync(DoesRepresentativeExists)
                .WithMessage("Representative with given id does not exist.");
        }

        private async Task<bool> DoesRepresentativeExists(UpdateRepresentativeCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                               .Where(p => p.IdRepresentative == command.IdRepresentative)
                                               .SingleOrDefaultAsync();

            return representative != null;
        }
    }
}
