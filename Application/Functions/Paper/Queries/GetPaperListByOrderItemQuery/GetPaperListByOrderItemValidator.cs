using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Queries.GetPaperListByOrderItemQuery
{
    public class GetPaperListByOrderItemValidator : AbstractValidator<GetPaperListByOrderItemQuery>
    {
        private readonly IApplicationContext _context;

        public GetPaperListByOrderItemValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Order item with given id does not exist.");
        }

        private async Task<bool> DoesOrderItemExists(GetPaperListByOrderItemQuery command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdOrderItem)
                                          .SingleOrDefaultAsync();

            return orderItem != null;
        }
    }
}
