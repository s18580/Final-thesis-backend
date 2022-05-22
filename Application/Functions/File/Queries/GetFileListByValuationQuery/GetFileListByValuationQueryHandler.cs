using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Queries.GetFileListByValuationQuery
{
    public class GetFileListByValuationQueryHandler : IRequestHandler<GetFileListByValuationQuery, GetFileListByValuationResponse>
    {
        private readonly IApplicationContext _context;

        public GetFileListByValuationQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetFileListByValuationResponse> Handle(GetFileListByValuationQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFileListByValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetFileListByValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var files = await _context.Files
                                      .Where(p => p.IdValuation == request.IdValuation)
                                      .ToListAsync();

            return new GetFileListByValuationResponse(files);
        }
    }
}
