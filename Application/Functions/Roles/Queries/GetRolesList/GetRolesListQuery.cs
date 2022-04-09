using Domain.Models.DictionaryModels;
using MediatR;

namespace Application.Functions.Roles.Queries.GetRolesList
{
    public class GetRolesListQuery :IRequest<List<Role>>
    {
    }
}
