using MediatR;

namespace Application.Functions.OrderItem.Queries.GetOrderItemQuery
{
    public class GetOrderItemQuery : IRequest<GetOrderItemDetailsDTO>
    {
        public int IdOrderItem { get; set; }
    }
}
