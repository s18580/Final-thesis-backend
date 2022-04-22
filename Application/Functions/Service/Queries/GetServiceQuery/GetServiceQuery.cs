using MediatR;

namespace Application.Functions.Service.Queries.GetServiceQuery
{
    public class GetServiceQuery : IRequest<Domain.Models.Service>
    {
        public int IdService { get; set; }
    }
}
