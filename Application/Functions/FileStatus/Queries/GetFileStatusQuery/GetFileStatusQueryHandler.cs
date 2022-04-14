using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileStatus.Queries.GetFileStatusQuery
{
    public class GetFileStatusQueryHandler : IRequestHandler<GetFileStatusQuery, Domain.Models.DictionaryModels.FileStatus>
    {
        private readonly IApplicationContext _context;

        public GetFileStatusQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DictionaryModels.FileStatus> Handle(GetFileStatusQuery request, CancellationToken cancellationToken)
        {
            var fileStatus = await _context.FileStatuses
                                            .Where(p => p.IdFileStatus == request.IdFileStatus)
                                            .SingleOrDefaultAsync();

            return fileStatus;
        }
    }
}
