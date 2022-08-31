using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Commands.UpdateOrderItemCommand
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, UpdateOrderItemResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateOrderItemCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateOrderItemResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedOrderItem = await _context.OrderItems
                                                  .Where(p => p.IdOrderItem == request.IdOrderItem)
                                                  .SingleAsync();

            if (selectedOrderItem.Name != request.Name) { selectedOrderItem.Name = request.Name; }
            if (selectedOrderItem.Circulation != request.Circulation) { selectedOrderItem.Circulation = request.Circulation; }
            if (selectedOrderItem.Capacity != request.Capacity) { selectedOrderItem.Capacity = request.Capacity; }
            if (selectedOrderItem.Comments != request.Comments) { selectedOrderItem.Comments = request.Comments; }
            if (selectedOrderItem.ExpectedCompletionDate != request.ExpectedCompletionDate) { selectedOrderItem.ExpectedCompletionDate = request.ExpectedCompletionDate; }
            if (selectedOrderItem.CompletionDate != request.CompletionDate) { selectedOrderItem.CompletionDate = request.CompletionDate; }
            if (selectedOrderItem.InsideFormat != request.InsideFormat) { selectedOrderItem.InsideFormat = request.InsideFormat; }
            if (selectedOrderItem.CoverFormat != request.CoverFormat) { selectedOrderItem.CoverFormat = request.CoverFormat; }
            if (selectedOrderItem.IdSelectedValuation != request.IdSelectedValuation)
            {
                selectedOrderItem.IdSelectedValuation = request.IdSelectedValuation;

                var selectedValuation = await _context.Valuations.Where(p => p.IdValuation == request.IdSelectedValuation).SingleAsync();
                selectedValuation.IdOrderItem = selectedOrderItem.IdOrderItem;
            }
            if (selectedOrderItem.IdDeliveryType != request.IdDeliveryType) { selectedOrderItem.IdDeliveryType = request.IdDeliveryType; }
            if (selectedOrderItem.IdBindingType != request.IdBindingType) { selectedOrderItem.IdBindingType = request.IdBindingType; }
            if (selectedOrderItem.IdOrderItemType != request.IdOrderItemType) { selectedOrderItem.IdOrderItemType = request.IdOrderItemType; }

            await _context.SaveChangesAsync();

            var selectedValuation2 = await _context.Valuations.Where(p => p.IdValuation == request.IdSelectedValuation).SingleAsync();

            return new UpdateOrderItemResponse();
        }
    }
}
