using MediatR;

namespace Application.Functions.Representative.Queries.GetCustomerRepresentativesListQuery
{
    public class GetCustomerRepresentativesListQuery : IRequest<List<Domain.Models.Representative>>
    {
    }
}
