using Domain.Models.DictionaryModels;
using MediatR;

namespace Application.Functions.Worksites.Queries.GetWorksitesList
{
    public class GetWorksitesListQuery : IRequest<List<Worksite>>
    {
    }
}
