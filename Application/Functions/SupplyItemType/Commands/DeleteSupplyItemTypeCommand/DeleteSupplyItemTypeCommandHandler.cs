using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.SupplyItemType.Commands.DeleteSupplyItemTypeCommand
{
    public class DeleteSupplyItemTypeCommandHandler : IRequestHandler<DeleteSupplyItemTypeCommand, DeleteSupplyItemTypeResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteSupplyItemTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteSupplyItemTypeResponse> Handle(DeleteSupplyItemTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSupplyItemTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteSupplyItemTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var supplyItemTypeDelete = await _context.SupplyItemTypes
                                                     .Where(p => p.IdSupplyItemType == request.IdSupplyItemType)
                                                     .Include(p => p.Supplies)
                                                     .SingleAsync();

            _context.SupplyItemTypes.Remove(supplyItemTypeDelete);
            await _context.SaveChangesAsync();

            return new DeleteSupplyItemTypeResponse();
        }
    }
}
