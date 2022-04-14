using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileType.Queries.GetFileTypeListQuery
{
    public class GetFileTypeListQueryHandler : IRequestHandler<GetFileTypeListQuery, List<Domain.Models.DictionaryModels.FileType>>
    {
        private readonly IApplicationContext _context;

        public GetFileTypeListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DictionaryModels.FileType>> Handle(GetFileTypeListQuery request, CancellationToken cancellationToken)
        {
            var fileTypes = await _context.FileTypes
                                          .ToListAsync();

            return fileTypes;
        }
    }
}
