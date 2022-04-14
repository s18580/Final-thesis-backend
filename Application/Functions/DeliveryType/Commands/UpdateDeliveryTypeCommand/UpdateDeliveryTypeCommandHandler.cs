using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveryType.Commands.UpdateDeliveryTypeCommand
{
    public class UpdateDeliveryTypeCommandHandler : IRequestHandler<UpdateDeliveryTypeCommand, UpdateDeliveryTypeResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateDeliveryTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateDeliveryTypeResponse> Handle(UpdateDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDeliveryTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateDeliveryTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedDeliveryType = await _context.DeliveryTypes
                                                      .Where(p => p.IdDeliveryType == request.IdDeliveryType)
                                                      .SingleAsync();

            if (selectedDeliveryType.Name != request.Name) { selectedDeliveryType.Name = request.Name; }

            await _context.SaveChangesAsync();

            return new UpdateDeliveryTypeResponse();
        }
    }
}
