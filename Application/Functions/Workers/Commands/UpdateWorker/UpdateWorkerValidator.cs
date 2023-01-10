using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Commands.UpdateWorker
{
    public class UpdateWorkerValidator : AbstractValidator<UpdateWorkerCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateWorkerValidator(IApplicationContext context)
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

            RuleFor(p => p.NewPassword)
                   .NotNull()
                   .WithMessage("User password is required.")
                   .MaximumLength(25)
                   .WithMessage("User password length can't be longer then 25 characters.");

            RuleFor(p => p).
                MustAsync(IsWorkerEmailUnique)
                .WithMessage("Worker with the same email address already exist.");

            RuleFor(p => p).
                MustAsync(DoesWorkerExists)
                .WithMessage("Worker with the given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesWorksiteExists)
                .WithMessage("Worksite with the given id does not exist.");
        }

        private async Task<bool> IsWorkerEmailUnique(UpdateWorkerCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                         .Where(p => p.IdWorker == command.Id)
                                         .SingleOrDefaultAsync();

            if (worker.EmailAddres != command.EmailAddres)
            {
                var otherWorker = await _context.Workers
                                            .Where(x => x.EmailAddres == command.EmailAddres)
                                            .SingleOrDefaultAsync();

                return otherWorker == null;
            }

            return true;
        }

        private async Task<bool> DoesWorkerExists(UpdateWorkerCommand command, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                         .Where(p => p.IdWorker == command.Id)
                                         .SingleOrDefaultAsync();

            return worker != null;
        }

        private async Task<bool> DoesWorksiteExists(UpdateWorkerCommand command, CancellationToken cancellationToken)
        {
            var worksite = await _context.Worksites
                                         .Where(x => x.IdWorksite == command.IdWorksite)
                                         .SingleOrDefaultAsync();

            return worksite != null || command.IdWorksite == null;
        }
    }
}
