using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Queries.GetFileListByOrderItemQuery
{
    public class GetFileListByOrderItemValidator : AbstractValidator<GetFileListByOrderItemQuery>
    {
        private readonly IApplicationContext _context;

        public GetFileListByOrderItemValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderItemExists)
                .WithMessage("Order item with given id does not exist.");
        }

        private async Task<bool> DoesOrderItemExists(GetFileListByOrderItemQuery command, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Where(p => p.IdOrderItem == command.IdOrderItem)
                                          .SingleOrDefaultAsync();

            return orderItem != null;
        }
    }
}
