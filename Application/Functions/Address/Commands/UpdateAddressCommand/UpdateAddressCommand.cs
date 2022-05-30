using MediatR;

namespace Application.Functions.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressCommand : IRequest<UpdateAddressResponse>
    {
        public int IdAddress { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
