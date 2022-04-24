using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Queries.GetValuationListByOrderItemQuery
{
    public class GetValuationListByOrderItemValidator : AbstractValidator<GetValuationListByOrderItemQuery>
    {
        private readonly IApplicationContext _context;

        public GetValuationListByOrderItemValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Order item with given id does not exist.");
        }

        private async Task<bool> DoesOrderItemExists(GetValuationListByOrderItemQuery command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdOrderItem)
                                          .SingleOrDefaultAsync();

            return orderItem != null;
        }
    }
}
