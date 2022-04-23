using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Queries.GetFileListByOrderQuery
{
    public class GetFileListByOrderValidator : AbstractValidator<GetFileListByOrderQuery>
    {
        private readonly IApplicationContext _context;

        public GetFileListByOrderValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesOrderExists)
                .WithMessage("Order with given id does not exist.");
        }

        private async Task<bool> DoesOrderExists(GetFileListByOrderQuery command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                                      .Where(p => p.IdOrder == command.IdOrder)
                                      .SingleOrDefaultAsync();

            return order != null;
        }
    }
}
