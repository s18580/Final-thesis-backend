using MediatR;

namespace Application.Functions.Supplier.Commands.CreateSupplierWithDataCommand
{
    public class CreateSupplierWithDataCommand : IRequest<CreateSupplierWithDataResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<DTOs.AddressDTO> Addresses { get; set; }
        public ICollection<DTOs.RepresentativeDTO> Representatives { get; set; }
    }
}
