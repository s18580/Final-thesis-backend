using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Commands.DeleteServiceCommand
{
    public class DeleteServiceValidator : AbstractValidator<DeleteServiceCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteServiceValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesServiceExists)
                .WithMessage("Service with given id does not exist.");
        }

        private async Task<bool> DoesServiceExists(DeleteServiceCommand command, CancellationToken cancellationToken)
        {
            var service = await _context.Services
                                        .Where(p => p.IdService == command.IdService)
                                        .SingleOrDefaultAsync();

            return service != null;
        }
    }
}
