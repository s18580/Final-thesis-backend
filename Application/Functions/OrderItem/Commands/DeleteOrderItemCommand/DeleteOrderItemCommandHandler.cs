using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Commands.DeleteOrderItemCommand
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, DeleteOrderItemResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteOrderItemCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteOrderItemResponse> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var orderItemDelete = await _context.OrderItems
                                                .Where(p => p.IdOrderItem == request.IdOrderItem)
                                                .SingleAsync();

            _context.OrderItems.Remove(orderItemDelete);
            await _context.SaveChangesAsync();

            return new DeleteOrderItemResponse();
        }
    }
}
