using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveryType.Commands.DeleteDeliveryTypeCommand
{
    public class DeleteDeliveryTypeCommandHandler : IRequestHandler<DeleteDeliveryTypeCommand, DeleteDeliveryTypeResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteDeliveryTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteDeliveryTypeResponse> Handle(DeleteDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteDeliveryTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteDeliveryTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var deliveryTypeDelete = await _context.DeliveryTypes
                                                     .Where(p => p.IdDeliveryType == request.IdDeliveryType)
                                                     .Include(p => p.OrderItems)
                                                     .SingleAsync();

            _context.DeliveryTypes.Remove(deliveryTypeDelete);
            await _context.SaveChangesAsync();

            return new DeleteDeliveryTypeResponse();
        }
    }
}
