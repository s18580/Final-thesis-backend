using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.User.Queries.LoginUserQuery
{
    public class LoginUserValidator : AbstractValidator<LoginUserQuery>
    {
        private readonly IApplicationContext _context;

        public LoginUserValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Password)
                .NotNull()
                   .WithMessage("Password is required.")
                   .NotEmpty()
                   .WithMessage("Password is required.")
                   .MaximumLength(30)
                   .WithMessage("Invalid email or password.");

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Invalid email or password.");
        }

        private async Task<bool> DoesWorkerExists(LoginUserQuery command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.EmailAddres == command.Email)
                                       .Where(p => p.Password != null)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }
    }
}
