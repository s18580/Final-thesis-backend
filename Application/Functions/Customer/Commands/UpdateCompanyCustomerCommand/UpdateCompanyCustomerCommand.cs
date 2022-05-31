using MediatR;

namespace Application.Functions.Customer.Commands.UpdateCompanyCustomerCommand
{
    public class UpdateCompanyCustomerCommand : IRequest<UpdateCompanyCustomerResponse>
    {
        public int IdCustomer { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }
    }
}
