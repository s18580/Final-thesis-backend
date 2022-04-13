using MediatR;

namespace Application.Functions.OrderItemType.Commands.DeleteOrderItemTypeCommand
{
    public class DeleteOrderItemTypeCommand : IRequest<DeleteOrderItemTypeResponse>
    {
        public int IdOrderItemType { get; set; }
    }
}
