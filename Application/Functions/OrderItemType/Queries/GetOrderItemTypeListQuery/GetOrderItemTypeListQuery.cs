using MediatR;

namespace Application.Functions.OrderItemType.Queries.GetOrderItemTypeListQuery
{
    public class GetOrderItemTypeListQuery : IRequest<List<Domain.Models.DictionaryModels.OrderItemType>>
    {
    }
}
