using MediatR;

namespace Application.Functions.OrderStatus.Commands.DeleteOrderStatusCommand
{
    public class DeleteOrderStatusCommand : IRequest<DeleteOrderStatusResponse>
    {
        public int IdOrderStatus { get; set; }
    }
}
