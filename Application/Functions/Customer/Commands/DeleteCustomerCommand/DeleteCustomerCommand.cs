using MediatR;

namespace Application.Functions.Customer.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
    {
        public int IdCustomer { get; set; }
    }
}
