using MediatR;

namespace Application.Functions.Representative.Queries.GetSupplierRepresentativesListQuery
{
    public class GetSupplierRepresentativesListQuery : IRequest<List<Domain.Models.Representative>>
    {
    }
}
