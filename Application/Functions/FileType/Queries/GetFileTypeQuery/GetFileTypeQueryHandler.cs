using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileType.Queries.GetFileTypeQuery
{
    public class GetFileTypeQueryHandler : IRequestHandler<GetFileTypeQuery, Domain.Models.DictionaryModels.FileType>
    {
        private readonly IApplicationContext _context;

        public GetFileTypeQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DictionaryModels.FileType> Handle(GetFileTypeQuery request, CancellationToken cancellationToken)
        {
            var fileType = await _context.FileTypes
                                               .Where(p => p.IdFileType == request.IdFileType)
                                               .SingleOrDefaultAsync();

            return fileType;
        }
    }
}
