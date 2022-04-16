using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Commands.CreateOrderCommand
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IApplicationContext _context;

        public CreateOrderValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                  .NotNull()
                  .WithMessage("Order name is required.")
                  .NotEmpty()
                  .WithMessage("Order name is required.")
                  .MaximumLength(255)
                  .WithMessage("Order name length can't be longer then 255 characters.");

            RuleFor(p => p.Note)
                  .MaximumLength(255)
                  .WithMessage("Note length can't be longer then 255 characters.");

            RuleFor(p => p.IsAuction)
                .NotNull()
                .WithMessage("IsAuction is required.");

            RuleFor(p => p).
                MustAsync(DoesOrderStatusExists)
                .WithMessage("Order status with given id does not exist.");

            RuleFor(p => p).
                MustAsync(DoesRepresentativeExists)
                .WithMessage("Representative with given id does not exist.");
        }

        private async Task<bool> DoesOrderStatusExists(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderStatus = await _context.OrderStatuses
                                            .Where(p => p.IdStatus == command.IdStatus)
                                            .SingleOrDefaultAsync();

            return orderStatus != null;
        }

        private async Task<bool> DoesRepresentativeExists(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                               .Where(p => p.IdRepresentative == command.IdRepresentative)
                                               .SingleOrDefaultAsync();

            return representative != null;
        }
    }
}
