using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetRepresentativeQuery
{
    public class GetRepresentativeQueryHandler : IRequestHandler<GetRepresentativeQuery, Domain.Models.Representative>
    {
        private readonly IApplicationContext _context;

        public GetRepresentativeQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Representative> Handle(GetRepresentativeQuery request, CancellationToken cancellationToken)
        {
            var representative = await _context.Representatives
                                               .Where(p => p.IdRepresentative == request.IdRepresentative)
                                               .SingleOrDefaultAsync();

            return representative;
        }
    }
}
