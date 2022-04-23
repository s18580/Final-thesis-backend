using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Queries.GetPaperQuery
{
    public class GetPaperQueryHandler : IRequestHandler<GetPaperQuery, Domain.Models.Paper>
    {
        private readonly IApplicationContext _context;

        public GetPaperQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Paper> Handle(GetPaperQuery request, CancellationToken cancellationToken)
        {
            var paper = await _context.Papers
                                      .Where(p => p.IdPaper == request.IdPaper)
                                      .SingleOrDefaultAsync();

            return paper;
        }
    }
}
