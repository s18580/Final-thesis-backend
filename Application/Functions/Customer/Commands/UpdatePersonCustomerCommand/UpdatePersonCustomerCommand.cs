using MediatR;

namespace Application.Functions.Customer.Commands.UpdatePersonCustomerCommand
{
    public class UpdatePersonCustomerCommand : IRequest<UpdatePersonCustomerResponse>
    {
        public int IdCustomer { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }
    }
}
