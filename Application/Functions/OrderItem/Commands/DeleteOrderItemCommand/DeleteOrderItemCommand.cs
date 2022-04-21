using MediatR;

namespace Application.Functions.OrderItem.Commands.DeleteOrderItemCommand
{
    public class DeleteOrderItemCommand : IRequest<DeleteOrderItemResponse>
    {
        public int IdOrderItem { get; set; }
    }
}
