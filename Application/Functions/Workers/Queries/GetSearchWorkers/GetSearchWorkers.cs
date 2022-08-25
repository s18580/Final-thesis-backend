using Application.Functions.DTOs.SearchersDTOs;
using MediatR;

namespace Application.Functions.Workers.Queries.GetSearchWorkers
{
    public class GetSearchWorkers : IRequest<List<SearchWorkerDTO>>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string WorksiteName { get; set; }
    }
}
