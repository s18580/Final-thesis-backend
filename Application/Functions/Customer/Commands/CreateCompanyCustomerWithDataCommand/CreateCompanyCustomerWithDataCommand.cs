using MediatR;

namespace Application.Functions.Customer.Commands.CreateCompanyCustomerWithDataCommand
{
    public class CreateCompanyCustomerWithDataCommand : IRequest<CreateCompanyCustomerWithDataResponse>
    {
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int IdWorker { get; set; }

        public ICollection<DTOs.AddressDTO> Addresses { get; set; }
        public ICollection<DTOs.RepresentativeDTO> Representatives { get; set; }
    }
}
