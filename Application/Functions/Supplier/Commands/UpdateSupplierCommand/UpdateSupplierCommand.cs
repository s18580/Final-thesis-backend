using MediatR;

namespace Application.Functions.Supplier.Commands.UpdateSupplierCommand
{
    public class UpdateSupplierCommand : IRequest<UpdateSupplierResponse>
    {
        public int IdSupplier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
