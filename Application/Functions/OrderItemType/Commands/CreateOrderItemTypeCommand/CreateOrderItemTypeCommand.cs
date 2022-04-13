using MediatR;

namespace Application.Functions.OrderItemType.Commands.CreateOrderItemTypeCommand
{
    public class CreateOrderItemTypeCommand : IRequest<CreateOrderItemTypeResponse>
    {
        public string Name { get; set; }
    }
}
