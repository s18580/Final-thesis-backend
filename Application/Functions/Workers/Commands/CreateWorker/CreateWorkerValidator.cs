using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Commands.CreateWorker
{
    public class CreateWorkerValidator : AbstractValidator<CreateWorkerCommand>
    {
        private readonly IApplicationContext _context;

        public CreateWorkerValidator(IApplicationContext context)
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

            RuleFor(p => p.EmailAddress)
                   .NotNull()
                   .WithMessage("Worker email address is required.")
                   .NotEmpty()
                   .WithMessage("Worker email address is required.")
                   .MaximumLength(255)
                   .WithMessage("Worker email address length can't be longer then 255 characters.");

            RuleFor(p => p).
                MustAsync(IsWorkerEmailUnique)
                .WithMessage("Worker with the same email address already exist");
        }

        private async Task<bool> IsWorkerEmailUnique(CreateWorkerCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                         .Where(x => x.EmailAddres == command.EmailAddress)
                                         .SingleOrDefaultAsync();

            return worker == null;
        }
    }
}
