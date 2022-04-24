using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ServiceName.Commands.CreateServiceNameCommand
{
    public class CreateServiceNameValidator : AbstractValidator<CreateServiceNameCommand>
    {
        private readonly IApplicationContext _context;

        public CreateServiceNameValidator(IApplicationContext context)
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
                MustAsync(IsServiceNameUnique)
                .WithMessage("Service name with the same name already exist");
        }

        private async Task<bool> IsServiceNameUnique(CreateServiceNameCommand command, CancellationToken cancellationToken)
        {
            var servicename = await _context.ServiceNames
                                            .Where(x => x.Name == command.Name)
                                            .SingleOrDefaultAsync();

            return servicename == null;
        }
    }
}
