using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Commands.CreateServiceCommand
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceCommand>
    {
        private readonly IApplicationContext _context;

        public CreateServiceValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Price)
                .GreaterThan(0);

            RuleFor(p => p).
                MustAsync(DoesServiceNameExists)
                .WithMessage("Service name with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesLinkExists)
                .WithMessage("Link with given id does not exist.");
        }

        private async Task<bool> DoesServiceNameExists(CreateServiceCommand command, CancellationToken cancellationToken)
        {
            var serviceName = await _context.ServiceNames
                                            .Where(p => p.IdServiceName == command.IdServiceName)
                                            .SingleOrDefaultAsync();

            return serviceName != null;
        }

        private async Task<bool> DoesLinkExists(CreateServiceCommand command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdLink)
                                          .SingleOrDefaultAsync();

            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdLink)
                                          .SingleOrDefaultAsync();

            return (valuation != null || orderItem != null);
        }
    }
}
