using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Commands.UpdateOrderItemCommand
{
    public class ServiceUpdateDTOValidator : AbstractValidator<ServiceUpdateDTO>
    {
        private readonly IApplicationContext _context;

        public ServiceUpdateDTOValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Price)
                .GreaterThan(0);

            RuleFor(p => p).
                MustAsync(DoesServiceNameExists)
                .WithMessage("Service name with given id does not exist.");

        }

        private async Task<bool> DoesServiceNameExists(ServiceUpdateDTO command, CancellationToken cancellationToken)
        {
            var serviceName = await _context.ServiceNames
                                            .Where(p => p.IdServiceName == command.IdServiceName)
                                            .SingleOrDefaultAsync();

            return serviceName != null;
        }
    }
}
