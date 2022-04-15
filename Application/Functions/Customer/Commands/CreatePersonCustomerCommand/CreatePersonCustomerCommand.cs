using MediatR;

namespace Application.Functions.Customer.Commands.CreatePersonCustomerCommand
{
    public class CreatePersonCustomerCommand : IRequest<CreatePersonCustomerResponse>
    {
        public string CompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }
    }
}
