using MediatR;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListBySupplyQuery
{
    public class GetDeliveriesAddressesListBySupplyQuery : IRequest<GetDeliveriesAddressesListBySupplyResponse>
    {
        public int IdSupply { get; set; }
    }
}
