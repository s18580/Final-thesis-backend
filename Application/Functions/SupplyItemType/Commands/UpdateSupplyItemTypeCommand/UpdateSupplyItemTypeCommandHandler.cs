using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.SupplyItemType.Commands.UpdateSupplyItemTypeCommand
{
    public class UpdateSupplyItemTypeCommandHandler : IRequestHandler<UpdateSupplyItemTypeCommand, UpdateSupplyItemTypeResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateSupplyItemTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateSupplyItemTypeResponse> Handle(UpdateSupplyItemTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSupplyItemTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateSupplyItemTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedSupplyItemType = await _context.SupplyItemTypes
                                                       .Where(p => p.IdSupplyItemType == request.IdSupplyItemType)
                                                       .SingleAsync();

            if (selectedSupplyItemType.Name != request.Name) { selectedSupplyItemType.Name = request.Name; }

            await _context.SaveChangesAsync();

            return new UpdateSupplyItemTypeResponse();
        }
    }
}
