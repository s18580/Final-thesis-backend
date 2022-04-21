using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Queries.GetOrderItemListByOrderIdQuery
{
    public class GetOrderItemListByOrderIdValidator : AbstractValidator<GetOrderItemListByOrderIdQuery>
    {
        private readonly IApplicationContext _context;

        public GetOrderItemListByOrderIdValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderExists)
                .WithMessage("Order with given id does not exist.");
        }

        private async Task<bool> DoesOrderExists(GetOrderItemListByOrderIdQuery command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                                      .Where(p => p.IdOrder == command.IdOrder)
                                      .SingleOrDefaultAsync();

            return order != null;
        }
    }
}
