using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ServiceName.Commands.DeleteServiceNameCommand
{
    public class DeleteServiceNameValidator : AbstractValidator<DeleteServiceNameCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteServiceNameValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesServiceNameExists)
                .WithMessage("Service name with given id does not exist.");
        }

        private async Task<bool> DoesServiceNameExists(DeleteServiceNameCommand command, CancellationToken cancellationToken)
        {
            var serviceName = await _context.ServiceNames
                                            .Where(p => p.IdServiceName == command.IdServiceName)
                                            .SingleOrDefaultAsync();

            return serviceName != null;
        }
    }
}
