using MediatR;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByAddressQuery
{
    public class GetDeliveriesAddressesListByAddressQuery : IRequest<GetDeliveriesAddressesListByAddressResponse>
    {
        public int IdAddress { get; set; }
    }
}
