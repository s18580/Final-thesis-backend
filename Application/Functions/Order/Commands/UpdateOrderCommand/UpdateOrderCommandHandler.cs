using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateOrderCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateOrderResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateOrderResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedOrder = await _context.Orders
                                              .Where(p => p.IdOrder == request.IdOrder)
                                              .SingleAsync();

            if (selectedOrder.Name != request.Name) { selectedOrder.Name = request.Name; }
            if (selectedOrder.OrderSubmissionDate != request.OrderSubmissionDate) { selectedOrder.OrderSubmissionDate = request.OrderSubmissionDate; }
            if (selectedOrder.Note != request.Note) { selectedOrder.Note = request.Note; }
            if (selectedOrder.IsAuction != request.IsAuction) { selectedOrder.IsAuction = request.IsAuction; }
            if (selectedOrder.ExpectedDeliveryDate != request.ExpectedDeliveryDate) { selectedOrder.ExpectedDeliveryDate = request.ExpectedDeliveryDate; }
            if (selectedOrder.DeliveryDate != request.DeliveryDate) { selectedOrder.DeliveryDate = request.DeliveryDate; }
            if (selectedOrder.OfferValidityDate != request.OfferValidityDate) { selectedOrder.OfferValidityDate = request.OfferValidityDate; }
            if (selectedOrder.IdRepresentative != request.IdRepresentative) { selectedOrder.IdRepresentative = request.IdRepresentative; }
            if (selectedOrder.IdStatus != request.IdStatus) { selectedOrder.IdStatus = request.IdStatus; }

            await _context.SaveChangesAsync();

            return new UpdateOrderResponse();
        }
    }
}
