using MediatR;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByOrderQuery
{
    public class GetDeliveriesAddressesListByOrderQuery : IRequest<GetDeliveriesAddressesListByOrderResponse>
    {
        public int IdOrder { get; set; }
    }
}
