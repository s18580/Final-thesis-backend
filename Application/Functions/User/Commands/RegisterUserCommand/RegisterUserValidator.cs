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

            RuleFor(p => p.anonymousUserData.Password)
                .NotNull()
                   .WithMessage("User password is required.")
                   .NotEmpty()
                   .WithMessage("User password is required.")
                   .MaximumLength(30)
                   .WithMessage("User password length can't be longer then 30 characters.");

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with given email does not exist.");
        }

        private async Task<bool> DoesWorkerExists(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.EmailAddres == command.anonymousUserData.Email)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
