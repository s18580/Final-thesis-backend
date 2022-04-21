using MediatR;

namespace Application.Functions.Address.Queries.GetAddressListByOwnerIdQuery
{
    public class GetAddressListByOwnerIdQuery : IRequest<GetAddressListByOwnerIdResponse>
    {
        public int IdOwner { get; set; }
    }
}
