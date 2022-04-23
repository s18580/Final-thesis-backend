using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Queries.GetFileListByOrderQuery
{
    public class GetFileListByOrderQueryHandler : IRequestHandler<GetFileListByOrderQuery, GetFileListByOrderResponse>
    {
        private readonly IApplicationContext _context;

        public GetFileListByOrderQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetFileListByOrderResponse> Handle(GetFileListByOrderQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFileListByOrderValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetFileListByOrderResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var files = await _context.Files
                                      .Where(p => p.IdLink == request.IdOrder)
                                      .ToListAsync();

            return new GetFileListByOrderResponse(files);
        }
    }
}
