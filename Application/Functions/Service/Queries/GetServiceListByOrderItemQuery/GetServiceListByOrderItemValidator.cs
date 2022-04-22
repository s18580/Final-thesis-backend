using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Queries.GetServiceListByOrderItemQuery
{
    public class GetServiceListByOrderItemValidator : AbstractValidator<GetServiceListByOrderItemQuery>
    {
        private readonly IApplicationContext _context;

        public GetServiceListByOrderItemValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Order item with given id does not exist.");
        }

        private async Task<bool> DoesOrderItemExists(GetServiceListByOrderItemQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == request.IdOrderItem)
                                          .SingleOrDefaultAsync();

            return orderItem != null;
        }
    }
}
