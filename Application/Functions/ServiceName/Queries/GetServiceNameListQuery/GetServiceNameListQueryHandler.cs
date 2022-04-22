using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ServiceName.Queries.GetServiceNameListQuery
{
    public class GetServiceNameListQueryHandler : IRequestHandler<GetServiceNameListQuery, List<Domain.Models.DictionaryModels.ServiceName>>
    {
        private readonly IApplicationContext _context;

        public GetServiceNameListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DictionaryModels.ServiceName>> Handle(GetServiceNameListQuery request, CancellationToken cancellationToken)
        {
            var serviceNames = await _context.ServiceNames
                                             .ToListAsync();

            return serviceNames;
        }
    }
}
