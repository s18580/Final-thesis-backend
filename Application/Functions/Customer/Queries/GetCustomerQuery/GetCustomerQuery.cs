using MediatR;

namespace Application.Functions.Customer.Queries.GetCustomerQuery
{
    public class GetCustomerQuery : IRequest<Domain.Models.Customer>
    {
        public int IdCustomer { get; set; }
    }
}
