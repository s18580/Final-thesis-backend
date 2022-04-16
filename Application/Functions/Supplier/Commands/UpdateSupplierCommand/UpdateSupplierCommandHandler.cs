using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supplier.Commands.UpdateSupplierCommand
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, UpdateSupplierResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateSupplierCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateSupplierResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSupplierValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateSupplierResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedSupplier = await _context.Suppliers
                                                 .Where(p => p.IdSupplier == request.IdSupplier)
                                                 .SingleAsync();

            if (selectedSupplier.Name != request.Name) { selectedSupplier.Name = request.Name; }
            if (selectedSupplier.Description != request.Description) { selectedSupplier.Description = request.Description; }
            if (selectedSupplier.PhoneNumber != request.PhoneNumber) { selectedSupplier.PhoneNumber = request.PhoneNumber; }
            if (selectedSupplier.EmailAddress != request.EmailAddress) { selectedSupplier.EmailAddress = request.EmailAddress; }

            await _context.SaveChangesAsync();

            return new UpdateSupplierResponse();
        }
    }
}
