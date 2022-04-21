using MediatR;

namespace Application.Functions.DeliveriesAddresses.Commands.DeleteDeliveriesAddressesCommand
{
    public class DeleteDeliveriesAddressesCommand : IRequest<DeleteDeliveriesAddressesResponse>
    {
        public int IdAddress { get; set; }
        public int IdLink { get; set; }
    }
}
