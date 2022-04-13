using MediatR;

namespace Application.Functions.OrderItemType.Commands.UpdateOrderItemTypeCommand
{
    public class UpdateOrderItemTypeCommand : IRequest<UpdateOrderItemTypeResponse>
    {
        public int IdOrderItemType { get; set; }
        public string Name { get; set; }
    }
}
