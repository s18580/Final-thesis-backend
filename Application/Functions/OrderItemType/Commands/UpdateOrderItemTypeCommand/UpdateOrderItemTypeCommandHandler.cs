using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItemType.Commands.UpdateOrderItemTypeCommand
{
    public class UpdateOrderItemTypeCommandHandler : IRequestHandler<UpdateOrderItemTypeCommand, UpdateOrderItemTypeResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateOrderItemTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateOrderItemTypeResponse> Handle(UpdateOrderItemTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderItemTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateOrderItemTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedOrderItemType = await _context.OrderItemTypes
                                                      .Where(p => p.IdOrderItemType == request.IdOrderItemType)
                                                      .SingleAsync();

            if (selectedOrderItemType.Name != request.Name) { selectedOrderItemType.Name = request.Name; }

            await _context.SaveChangesAsync();

            return new UpdateOrderItemTypeResponse();
        }
    }
}
