using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Queries.GetFileListByOrderItemQuery
{
    public class GetFileListByOrderItemQueryHandler : IRequestHandler<GetFileListByOrderItemQuery, GetFileListByOrderItemResponse>
    {
        private readonly IApplicationContext _context;

        public GetFileListByOrderItemQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetFileListByOrderItemResponse> Handle(GetFileListByOrderItemQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFileListByOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetFileListByOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var files = await _context.Files
                                      .Where(p => p.IdOrderItem == request.IdOrderItem)
                                      .ToListAsync();

            return new GetFileListByOrderItemResponse(files);
        }
    }
}
