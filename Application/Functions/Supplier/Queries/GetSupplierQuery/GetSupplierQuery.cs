using MediatR;

namespace Application.Functions.Supplier.Queries.GetSupplierQuery
{
    public class GetSupplierQuery : IRequest<Domain.Models.Supplier>
    {
        public int IdSupplier { get; set; }
    }
}
