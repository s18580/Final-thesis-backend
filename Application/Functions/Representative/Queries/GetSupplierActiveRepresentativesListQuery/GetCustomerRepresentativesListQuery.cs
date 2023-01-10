using MediatR;

namespace Application.Functions.Representative.Queries.GetSupplierActiveRepresentativesListQuery
{
    public class GetSupplierActiveRepresentativesListQuery : IRequest<List<Domain.Models.Representative>>
    {
        public int Id { get; set; }
    }
}
