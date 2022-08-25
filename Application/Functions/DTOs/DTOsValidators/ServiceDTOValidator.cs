using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DTOs.DTOsValidators
{
    public class ServiceDTOValidator : AbstractValidator<ServiceDTO>
    {
        private readonly IApplicationContext _context;

        public ServiceDTOValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Price)
                .GreaterThan(0);

            RuleFor(p => p).
                MustAsync(DoesServiceNameExists)
                .WithMessage("Service name with given id does not exist.");

        }

        private async Task<bool> DoesServiceNameExists(ServiceDTO command, CancellationToken cancellationToken)
        {
            var serviceName = await _context.ServiceNames
                                            .Where(p => p.IdServiceName == command.IdServiceName)
                                            .SingleOrDefaultAsync();

            return serviceName != null;
        }
    }
}
