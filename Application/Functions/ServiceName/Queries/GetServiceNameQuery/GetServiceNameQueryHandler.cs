using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ServiceName.Queries.GetServiceNameQuery
{
    public class GetServiceNameQueryHandler : IRequestHandler<GetServiceNameQuery, Domain.Models.DictionaryModels.ServiceName>
    {
        private readonly IApplicationContext _context;

        public GetServiceNameQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.DictionaryModels.ServiceName> Handle(GetServiceNameQuery request, CancellationToken cancellationToken)
        {
            var serviceName = await _context.ServiceNames
                                            .Where(p => p.IdServiceName == request.IdServiceName)
                                            .SingleOrDefaultAsync();

            return serviceName;
        }
    }
}
