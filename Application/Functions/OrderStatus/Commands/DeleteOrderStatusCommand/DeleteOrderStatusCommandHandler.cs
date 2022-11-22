using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderStatus.Commands.DeleteOrderStatusCommand
{
    public class DeleteOrderStatusCommandHandler : IRequestHandler<DeleteOrderStatusCommand, DeleteOrderStatusResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteOrderStatusCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteOrderStatusResponse> Handle(DeleteOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteOrderStatusValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteOrderStatusResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var orderStatusDelete = await _context.OrderStatuses
                                                     .Where(p => p.IdStatus == request.IdOrderStatus)
                                                     .Include(p => p.Orders)
                                                     .SingleAsync();

            _context.OrderStatuses.Remove(orderStatusDelete);
            await _context.SaveChangesAsync();

            return new DeleteOrderStatusResponse();
        }
    }
}
