using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Queries.GetColorListByOrderItemQuery
{
    public class GetColorListByOrderItemValidator : AbstractValidator<GetColorListByOrderItemQuery>
    {
        private readonly IApplicationContext _context;

        public GetColorListByOrderItemValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Order item with given id does not exist.");
        }

        private async Task<bool> DoesOrderItemExists(GetColorListByOrderItemQuery command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                      .Where(p => p.IdOrderItem == command.IdOrderItem)
                                      .SingleOrDefaultAsync();

            return orderItem != null;
        }
    }
}
