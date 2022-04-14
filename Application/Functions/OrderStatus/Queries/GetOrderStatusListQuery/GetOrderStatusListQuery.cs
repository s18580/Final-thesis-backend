using MediatR;

namespace Application.Functions.OrderStatus.Queries.GetOrderStatusListQuery
{
    public class GetOrderStatusListQuery : IRequest<List<Domain.Models.DictionaryModels.OrderStatus>>
    {
    }
}
