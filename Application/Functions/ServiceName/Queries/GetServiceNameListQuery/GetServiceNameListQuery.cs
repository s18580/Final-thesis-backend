using MediatR;

namespace Application.Functions.ServiceName.Queries.GetServiceNameListQuery
{
    public class GetServiceNameListQuery : IRequest<List<Domain.Models.DictionaryModels.ServiceName>>
    {
    }
}
