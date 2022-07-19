using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ServiceName.Commands.UpdateServiceNameCommand
{
    public class UpdateServiceNameValidator : AbstractValidator<UpdateServiceNameCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateServiceNameValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Role name is required.")
                   .NotEmpty()
                   .WithMessage("Role name is required.")
                   .MaximumLength(30)
                   .WithMessage("Role name length can't be longer then 30 characters.");

            RuleFor(p => p.MinimumCirculation)
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.MinimumPrice)
                .GreaterThan(0);

            RuleFor(p => p.DefaultPrice)
                .GreaterThan(0);

            RuleFor(p => p).
                MustAsync(DoesServiceNameExists)
                .WithMessage("Service name with given id does not exist.");

            RuleFor(p => p).
                MustAsync(IsServiceNameUnique)
                .WithMessage("Service name with the same name already exist");
        }

        private async Task<bool> IsServiceNameUnique(UpdateServiceNameCommand command, CancellationToken cancellationToken)
        {
            var servicename = await _context.ServiceNames
                                            .Where(p => p.IdServiceName != command.IdServiceName)
                                            .Where(x => x.Name == command.Name)
                                            .SingleOrDefaultAsync();

            return servicename == null;
        }

        private async Task<bool> DoesServiceNameExists(UpdateServiceNameCommand command, CancellationToken cancellationToken)
        {
            var serviceName = await _context.ServiceNames
                                            .Where(p => p.IdServiceName == command.IdServiceName)
                                            .SingleOrDefaultAsync();

            return serviceName != null;
        }
    }
}
