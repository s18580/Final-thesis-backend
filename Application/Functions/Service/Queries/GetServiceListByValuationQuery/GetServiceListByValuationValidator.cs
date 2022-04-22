using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Queries.GetServiceListByValuationQuery
{
    public class GetServiceListByValuationValidator : AbstractValidator<GetServiceListByValuationQuery>
    {
        private readonly IApplicationContext _context;

        public GetServiceListByValuationValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesValuationExists)
                .WithMessage("Valuation with given id does not exist.");
        }

        private async Task<bool> DoesValuationExists(GetServiceListByValuationQuery request, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == request.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation != null;
        }
    }
}
