using Domain.Models.DictionaryModels;
using MediatR;

namespace Application.Functions.Roles.Queries.GetRole
{
    public class GetRoleQuery :IRequest<Role>
    {
        public int Id { get; set; }
    }
}
