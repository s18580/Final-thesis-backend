using Application.Services;
using Domain.Models.DictionaryModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Roles.Queries.GetRole
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Role>
    {
        private readonly IApplicationContext _context;

        public GetRoleQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Role> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles
                                   .Where(p => p.IdRole == request.Id)
                                   .SingleOrDefaultAsync();

            return role;
        }
    }
}
