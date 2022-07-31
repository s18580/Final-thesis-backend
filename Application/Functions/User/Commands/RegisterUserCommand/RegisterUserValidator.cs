using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.User.Commands.RegisterUserCommand
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IApplicationContext _context;

        public RegisterUserValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Worker name is required.")
                   .NotEmpty()
                   .WithMessage("Worker name is required.")
                   .MaximumLength(32)
                   .WithMessage("Worker name length can't be longer then 32 characters.");

            RuleFor(p => p.LastName)
                   .NotNull()
                   .WithMessage("Worker last name is required.")
                   .NotEmpty()
                   .WithMessage("Worker last name is required.")
                   .MaximumLength(64)
                   .WithMessage("Worker last name length can't be longer then 64 characters.");

            RuleFor(p => p.PhoneNumber)
                   .MaximumLength(32)
                   .WithMessage("Worker phone number length can't be longer then 32 characters.");

            RuleFor(p => p.EmailAddres)
                   .NotNull()
                   .WithMessage("Worker email address is required.")
                   .NotEmpty()
                   .WithMessage("Worker email address is required.")
                   .MaximumLength(255)
                   .WithMessage("Worker email address length can't be longer then 255 characters.")
                   .EmailAddress()
                   .WithMessage("Email format is not correct.");

            RuleFor(p => p.Password)
                .NotNull()
                   .WithMessage("User password is required.")
                   .NotEmpty()
                   .WithMessage("User password is required.")
                   .MaximumLength(30)
                   .WithMessage("User password length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(IsWorkerEmailUnique)
                .WithMessage("Worker with the same email address already exist.");

            RuleFor(p => p).
                MustAsync(DoesWorksiteExists)
                .WithMessage("Worksite with the given id does not exist.");
        }

        private async Task<bool> IsWorkerEmailUnique(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                         .Where(x => x.EmailAddres == command.EmailAddres)
                                         .SingleOrDefaultAsync();

            return worker == null;
        }

        private async Task<bool> DoesWorksiteExists(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var worksite = await _context.Worksites
                                         .Where(x => x.IdWorksite == command.IdWorksite)
                                         .SingleOrDefaultAsync();

            return worksite != null;
        }
    }
}
