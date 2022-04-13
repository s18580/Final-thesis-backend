using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItemType.Commands.DeleteOrderItemTypeCommand
{
    public class DeleteOrderItemTypeCommandHandler : IRequestHandler<DeleteOrderItemTypeCommand, DeleteOrderItemTypeResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteOrderItemTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteOrderItemTypeResponse> Handle(DeleteOrderItemTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteOrderItemTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteOrderItemTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var orderItemTypeDelete = await _context.OrderItemTypes
                                                     .Where(p => p.IdOrderItemType == request.IdOrderItemType)
                                                     .SingleAsync();

            _context.OrderItemTypes.Remove(orderItemTypeDelete);
            await _context.SaveChangesAsync();

            return new DeleteOrderItemTypeResponse();
        }
    }
}
