using MediatR;

namespace Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand
{
    public class CreateOrderStatusCommand : IRequest<CreateOrderStatusResponse>
    {
        public string Name { get; set; }
        public string ChipColor { get; set; }
    }
}
