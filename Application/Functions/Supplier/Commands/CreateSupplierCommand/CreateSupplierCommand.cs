using MediatR;

namespace Application.Functions.Supplier.Commands.CreateSupplierCommand
{
    public class CreateSupplierCommand : IRequest<CreateSupplierResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
