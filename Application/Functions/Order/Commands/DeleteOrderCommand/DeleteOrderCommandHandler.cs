using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteOrderCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteOrderResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteOrderValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteOrderResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var orderDelete = await _context.Orders
                                            .Where(p => p.IdOrder == request.IdOrder)
                                            .SingleAsync();

            _context.Orders.Remove(orderDelete);
            await _context.SaveChangesAsync();

            return new DeleteOrderResponse();
        }
    }
}
