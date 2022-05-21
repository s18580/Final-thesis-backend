using MediatR;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesQuery
{
    public class GetDeliveriesAddressesQuery : IRequest<Domain.Models.DeliveriesAddresses>
    {
        public int IdDeliveriesAddresses { get; set; }
    }
}
