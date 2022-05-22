using MediatR;

namespace Application.Functions.Address.Queries.GetAddressListByCustomerIdQuery
{
    public class GetAddressListByCustomerIdQuery : IRequest<GetAddressListByCustomerIdResponse>
    {
        public int IdCustomer { get; set; }
    }
}
