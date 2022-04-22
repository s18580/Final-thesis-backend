using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Queries.GetServiceQuery
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, Domain.Models.Service>
    {
        private readonly IApplicationContext _context;

        public GetServiceQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Service> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var service = await _context.Services
                                         .Where(p => p.IdService == request.IdService)
                                         .SingleOrDefaultAsync();

            return service;
        }
    }
}
