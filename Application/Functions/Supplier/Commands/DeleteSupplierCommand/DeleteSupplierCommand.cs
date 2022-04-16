using MediatR;

namespace Application.Functions.Supplier.Commands.DeleteSupplierCommand
{
    public class DeleteSupplierCommand : IRequest<DeleteSupplierResponse>
    {
        public int IdSupplier { get; set; }
    }
}
