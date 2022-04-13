using MediatR;

namespace Application.Functions.OrderItemType.Queries.GetOrderItemTypeQuery
{
    public class GetOrderItemTypeQuery : IRequest<Domain.Models.DictionaryModels.OrderItemType>
    {
        public int IdOrderItemType { get; set; }
    }
}
