using MediatR;

namespace Application.Functions.DeliveryType.Commands.UpdateDeliveryTypeCommand
{
    public class UpdateDeliveryTypeCommand : IRequest<UpdateDeliveryTypeResponse>
    {
        public int IdDeliveryType { get; set; }
        public string Name { get; set; }
    }
}
