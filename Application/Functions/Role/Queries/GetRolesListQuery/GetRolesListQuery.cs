using MediatR;

namespace Application.Functions.Role.Queries.GetRolesListQuery
{
    public class GetRolesListQuery : IRequest<List<Domain.Models.DictionaryModels.Role>>
    {
    }
}
