using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Queries.GetFileQuery
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, Domain.Models.File>
    {
        private readonly IApplicationContext _context;

        public GetFileQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.File> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var file = await _context.Files
                                     .Where(p => p.IdFile == request.IdFile)
                                     .SingleOrDefaultAsync();

            return file;
        }
    }
}
