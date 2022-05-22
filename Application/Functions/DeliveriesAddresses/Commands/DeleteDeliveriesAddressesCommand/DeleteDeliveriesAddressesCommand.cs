using MediatR;

namespace Application.Functions.DeliveriesAddresses.Commands.DeleteDeliveriesAddressesCommand
{
    public class DeleteDeliveriesAddressesCommand : IRequest<DeleteDeliveriesAddressesResponse>
    {
        public int IdDeliveriesAddresses { get; set; }
    }
}
