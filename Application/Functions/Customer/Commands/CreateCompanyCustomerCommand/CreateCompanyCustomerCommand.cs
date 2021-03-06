using MediatR;

namespace Application.Functions.Customer.Commands.CreateCompanyCustomerCommand
{
    public class CreateCompanyCustomerCommand : IRequest<CreateCompanyCustomerResponse>
    {
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }
    }
}
