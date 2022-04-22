using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Commands.UpdateServiceCommand
{
    public class UpdateServiceValidator : AbstractValidator<UpdateServiceCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateServiceValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesServiceExists)
                .WithMessage("Service with given id does not exist.");
        }

        private async Task<bool> DoesServiceExists(UpdateServiceCommand command, CancellationToken cancellationToken)
        {
            var service = await _context.Services
                                        .Where(p => p.IdService == command.IdService)
                                        .SingleOrDefaultAsync();

            return service != null;
        }
    }
}
