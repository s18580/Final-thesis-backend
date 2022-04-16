using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetRepresentativeListQuery
{
    public class GetRepresentativeListQueryHandler : IRequestHandler<GetRepresentativeListQuery, List<Domain.Models.Representative>>
    {
        private readonly IApplicationContext _context;

        public GetRepresentativeListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Representative>> Handle(GetRepresentativeListQuery request, CancellationToken cancellationToken)
        {
            var representatives = await _context.Representatives
                                                .ToListAsync();

            return representatives;
        }
    }
}
