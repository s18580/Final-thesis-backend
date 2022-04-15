using MediatR;

namespace Application.Functions.Customer.Queries.GetCustomerListQuery
{
    public class GetCustomerListQuery : IRequest<List<Domain.Models.Customer>>
    {
    }
}
