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

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var valuations = await _context.Valuations
                                            .Include(p => p.Colors)
                                            .Include(p => p.Papers)
                                            .Include(p => p.Services)
                                            .Include(p => p.PriceListPrices)
                                            .Where(p => p.IdOrderItem == request.IdOrderItem).ToListAsync();

                _context.Valuations.RemoveRange(valuations);
                await _context.SaveChangesAsync();

                var orderItemDelete = await _context.OrderItems
                                                    .Include(p => p.Supplies)
                                                    .ThenInclude(p => p.DeliveriesAddresses)
                                                    .Include(p => p.Colors)
                                                    .Include(p => p.Papers)
                                                    .Include(p => p.Services)
                                                    .Where(p => p.IdOrderItem == request.IdOrderItem)
                                                    .SingleAsync();

                _context.OrderItems.Remove(orderItemDelete);
                await _context.SaveChangesAsync();

                dbContextTransaction.Commit();
            }

            return new DeleteOrderItemResponse();
        }
    }
}
