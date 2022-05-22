using MediatR;

namespace Application.Functions.Address.Queries.GetAddressListBySupplierIdQuery
{
    public class GetAddressListBySupplierIdQuery : IRequest<GetAddressListBySupplierIdResponse>
    {
        public int IdSupplier { get; set; }
    }
}
