using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Queries.GetFileListByValuationQuery
{
    public class GetFileListByValuationValidator : AbstractValidator<GetFileListByValuationQuery>
    {
        private readonly IApplicationContext _context;

        public GetFileListByValuationValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesValuationExists)
                .WithMessage("Valuation with given id does not exist.");
        }

        private async Task<bool> DoesValuationExists(GetFileListByValuationQuery command, CancellationToken cancellationToken)
        {
            var valuation = await _context.Valuations
                                          .Where(p => p.IdValuation == command.IdValuation)
                                          .SingleOrDefaultAsync();

            return valuation != null;
        }
    }
}
