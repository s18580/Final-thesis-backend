using MediatR;

namespace Application.Functions.ServiceName.Queries.GetServiceNameQuery
{
    public class GetServiceNameQuery : IRequest<Domain.Models.DictionaryModels.ServiceName>
    {
        public int IdServiceName { get; set; }
    }
}
