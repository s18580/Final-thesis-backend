using Application.Services;
using Domain.Models.DictionaryModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Worksites.Queries.GetWorksitesList
{
    public class GetWorksitesListQueryHandler : IRequestHandler<GetWorksitesListQuery, List<Worksite>>
    {
        private readonly IApplicationContext _context;

        public GetWorksitesListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Worksite>> Handle(GetWorksitesListQuery request, CancellationToken cancellationToken)
        {
            var worksites = await _context.Worksites.ToListAsync();

            return worksites;
        }
    }
}
