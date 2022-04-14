using MediatR;

namespace Application.Functions.OrderStatus.Commands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusCommand : IRequest<UpdateOrderStatusResponse>
    {
        public int IdOrderStatus { get; set; }
        public string Name { get; set; }
    }
}
