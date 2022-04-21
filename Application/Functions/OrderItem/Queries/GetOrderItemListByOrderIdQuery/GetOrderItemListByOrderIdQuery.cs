using MediatR;

namespace Application.Functions.OrderItem.Queries.GetOrderItemListByOrderIdQuery
{
    public class GetOrderItemListByOrderIdQuery : IRequest<GetOrderItemListByOrderIdResponse>
    {
        public int IdOrder { get; set; }
    }
}
