using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileStatus.Queries.GetFileStatusListQuery
{
    public class GetFileStatusListQueryHandler : IRequestHandler<GetFileStatusListQuery, List<Domain.Models.DictionaryModels.FileStatus>>
    {
        private readonly IApplicationContext _context;

        public GetFileStatusListQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<List<Domain.Models.DictionaryModels.FileStatus>> Handle(GetFileStatusListQuery request, CancellationToken cancellationToken)
        {
            var fileStatuses = await _context.FileStatuses
                                             .ToListAsync();

            return fileStatuses;
        }
    }
}
