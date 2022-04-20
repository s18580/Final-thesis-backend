using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Queries.GetAssignmentListByOrderQuery
{
    public class GetAssignmentListByOrderValidator : AbstractValidator<GetAssignmentListByOrderQuery>
    {
        private readonly IApplicationContext _context;

        public GetAssignmentListByOrderValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderExists)
                .WithMessage("Order with given ids already exist.");
        }

        private async Task<bool> DoesOrderExists(GetAssignmentListByOrderQuery command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                                      .Where(p => p.IdOrder == command.IdOrder)
                                      .SingleOrDefaultAsync();

            return order != null;
        }
    }
}
