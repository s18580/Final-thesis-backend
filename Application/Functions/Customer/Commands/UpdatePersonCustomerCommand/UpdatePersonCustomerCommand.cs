using MediatR;

namespace Application.Functions.Customer.Commands.UpdatePersonCustomerCommand
{
    public class UpdatePersonCustomerCommand : IRequest<UpdatePersonCustomerResponse>
    {
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int IdWorker { get; set; }
    }
}
