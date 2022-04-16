using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supplier.Commands.DeleteSupplierCommand
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, DeleteSupplierResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteSupplierCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteSupplierResponse> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSupplierValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteSupplierResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var supplierDelete = await _context.Suppliers
                                               .Where(p => p.IdSupplier == request.IdSupplier)
                                               .SingleAsync();

            _context.Suppliers.Remove(supplierDelete);
            await _context.SaveChangesAsync();

            return new DeleteSupplierResponse();
        }
    }
}
