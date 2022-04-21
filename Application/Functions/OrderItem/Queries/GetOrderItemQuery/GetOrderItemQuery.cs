using MediatR;

namespace Application.Functions.OrderItem.Queries.GetOrderItemQuery
{
    public class GetOrderItemQuery : IRequest<Domain.Models.OrderItem>
    {
        public int IdOrderItem { get; set; }
    }
}
