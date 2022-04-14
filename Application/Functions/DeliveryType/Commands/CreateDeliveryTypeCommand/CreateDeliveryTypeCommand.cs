using MediatR;

namespace Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand
{
    public class CreateDeliveryTypeCommand : IRequest<CreateDeliveryTypeResponse>
    {
        public string Name { get; set; }
    }
}
