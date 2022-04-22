using Application.Services;
using Domain.Models.DictionaryModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Roles.Queries.GetRolesList
{
    public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, List<Role>>
    {
        private readonly IApplicationContext _context;

        public GetRolesListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.ToListAsync();

            return roles;
        }
    }
}
