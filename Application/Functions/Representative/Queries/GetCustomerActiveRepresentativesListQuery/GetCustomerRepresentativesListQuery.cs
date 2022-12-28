using MediatR;

namespace Application.Functions.Representative.Queries.GetCustomerActiveRepresentativesListQuery
{
    public class GetCustomerActiveRepresentativesListQuery : IRequest<List<Domain.Models.Representative>>
    {
        public int Id { get; set; }
    }
}
