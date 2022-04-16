using MediatR;

namespace Application.Functions.Order.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommand : IRequest<DeleteOrderResponse>
    {
        public int IdOrder { get; set; }
    }
}
