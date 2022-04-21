using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Commands.UpdateSupplyCommand
{
    public class UpdateSupplyCommandHandler : IRequestHandler<UpdateSupplyCommand, UpdateSupplyResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateSupplyCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateSupplyResponse> Handle(UpdateSupplyCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSupplyValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateSupplyResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedSupply = await _context.Supplies
                                               .Where(p => p.IdSupply == request.IdSupply)
                                               .SingleAsync();

            if (selectedSupply.ItemDescription != request.ItemDescription) { selectedSupply.ItemDescription = request.ItemDescription; }
            if (selectedSupply.Price != request.Price) { selectedSupply.Price = request.Price; }
            if (selectedSupply.Quantity != request.Quantity) { selectedSupply.Quantity = request.Quantity; }
            if (selectedSupply.SupplyDate != request.SupplyDate) { selectedSupply.SupplyDate = request.SupplyDate; }
            if (selectedSupply.IsReceived != request.IsReceived) { selectedSupply.IsReceived = request.IsReceived; }
            if (selectedSupply.IdSupplyItemType != request.IdSupplyItemType) { selectedSupply.IdSupplyItemType = request.IdSupplyItemType; }
            if (selectedSupply.IdRepresentative != request.IdRepresentative) { selectedSupply.IdRepresentative = request.IdRepresentative; }

            await _context.SaveChangesAsync();

            return new UpdateSupplyResponse();
        }
    }
}
