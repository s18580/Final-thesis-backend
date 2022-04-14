using MediatR;

namespace Application.Functions.DeliveryType.Commands.DeleteDeliveryTypeCommand
{
    public class DeleteDeliveryTypeCommand : IRequest<DeleteDeliveryTypeResponse>
    {
        public int IdDeliveryType { get; set; }
    }
}
