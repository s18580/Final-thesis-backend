using MediatR;

namespace Application.Functions.Representative.Queries.GetRepresentativeListBySupplierQuery
{
    public class GetRepresentativeListBySupplierQuery : IRequest<GetRepresentativeListBySupplierResponse>
    {
        public int SupplierId { get; set; }
    }
}
