using MediatR;

namespace Application.Functions.DeliveriesAddresses.Commands.CreateDeliveriesAddressesCommand
{
    public class CreateDeliveriesAddressesCommand : IRequest<CreateDeliveriesAddressesResponse>
    {
        public int IdAddress { get; set; }
        public int? IdOrder { get; set; }
        public int? IdSupply { get; set; }
    }
}
