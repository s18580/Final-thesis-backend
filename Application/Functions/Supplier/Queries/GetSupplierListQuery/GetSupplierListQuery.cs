using MediatR;

namespace Application.Functions.Supplier.Queries.GetSupplierListQuery
{
    public class GetSupplierListQuery : IRequest<List<Domain.Models.Supplier>>
    {
    }
}
