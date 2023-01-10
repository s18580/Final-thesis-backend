using MediatR;

namespace Application.Functions.Address.Commands.CreateAddressCommand
{
    public class CreateAddressCommand : IRequest<CreateAddressResponse>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public bool IsDisabled { get; set; }
        public int? IdSupplier { get; set; }
        public int? IdCustomer { get; set; }
    }
}
