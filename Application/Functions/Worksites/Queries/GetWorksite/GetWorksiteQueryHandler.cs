using Application.Services;
using Domain.Models.DictionaryModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Worksites.Queries.GetWorksite
{
    public class GetWorksiteQueryHandler : IRequestHandler<GetWorksiteQuery, Worksite>
    {
        private readonly IApplicationContext _context;

        public GetWorksiteQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Worksite> Handle(GetWorksiteQuery request, CancellationToken cancellationToken)
        {
            var worksite = await _context.Worksites
                                   .Where(p => p.IdWorksite == request.Id)
                                   .SingleOrDefaultAsync();

            return worksite;
        }
    }
}
