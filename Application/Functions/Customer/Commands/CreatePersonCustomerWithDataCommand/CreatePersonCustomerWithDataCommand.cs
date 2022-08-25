using MediatR;

namespace Application.Functions.Customer.Commands.CreatePersonCustomerWithDataCommand
{
    public class CreatePersonCustomerWithDataCommand : IRequest<CreatePersonCustomerWithDataResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }

        public ICollection<DTOs.AddressDTO> Addresses { get; set; }
        public ICollection<DTOs.RepresentativeDTO> Representatives { get; set; }
    }
}
