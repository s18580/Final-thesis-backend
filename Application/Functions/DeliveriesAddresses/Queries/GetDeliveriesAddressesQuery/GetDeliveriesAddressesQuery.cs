using MediatR;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesQuery
{
    public class GetDeliveriesAddressesQuery : IRequest<Domain.Models.DeliveriesAddresses>
    {
        public int IdAddress { get; set; }
        public int IdLink { get; set; }
    }
}
