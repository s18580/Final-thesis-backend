using Domain.Models.DictionaryModels;
using MediatR;

namespace Application.Functions.Worksites.Queries.GetWorksite
{
    public class GetWorksiteQuery : IRequest<Worksite>
    {
        public int Id { get; set; }
    }
}
