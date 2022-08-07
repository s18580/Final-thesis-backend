using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.User.Commands.RefreshTokenCommand
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
    {
        private readonly IApplicationContext _context;

        public RefreshTokenValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.userEmail)
                .NotNull()
                .WithMessage("User email is required.")
                .NotEmpty()
                .WithMessage("User email is required.")
                .MaximumLength(255)
                .WithMessage("User email length can't be longer then 255 characters.");

            RuleFor(p => p).
                MustAsync(DoesUserExists)
                .WithMessage("Invalid refresh token.");

            RuleFor(p => p).
                MustAsync(DoesTokenEquals)
                .WithMessage("Invalid refresh token.");

            RuleFor(p => p).
                MustAsync(IsTokenValid)
                .WithMessage("Token expired.");
        }

        private async Task<bool> DoesUserExists(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.EmailAddres == command.userEmail)
                                       .Where(p => p.IsDisabled == false)
                                       .SingleOrDefaultAsync();

            return worker != null;
        }

        private async Task<bool> DoesTokenEquals(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                      .Where(p => p.EmailAddres == command.userEmail)
                                      .Where(p => p.RefreshToken == command.refreshToken)
                                      .SingleOrDefaultAsync();

            return worker != null;
        }

        private async Task<bool> IsTokenValid(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.EmailAddres == command.userEmail)
                                       .SingleOrDefaultAsync();
            if (worker != null)
            {
                return worker.TokenExpires > DateTime.Now;
            }
            else
            {
                return false;
            }
        }
    }
}
