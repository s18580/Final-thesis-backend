using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Role.Queries.GetRolesListQuery
{
    public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, List<Domain.Models.DictionaryModels.Role>>
    {
        private readonly IApplicationContext _context;

        public GetRolesListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DictionaryModels.Role>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles
                                      .ToListAsync();

            return roles;
        }
    }
}
