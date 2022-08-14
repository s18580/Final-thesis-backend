using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderStatus.Commands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, UpdateOrderStatusResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateOrderStatusCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateOrderStatusResponse> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderStatusValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateOrderStatusResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedOrderStatus = await _context.OrderStatuses
                                                    .Where(p => p.IdStatus == request.IdOrderStatus)
                                                    .SingleAsync();

            if (selectedOrderStatus.Name != request.Name) { selectedOrderStatus.Name = request.Name; }
            if (selectedOrderStatus.ChipColor != request.ChipColor) { selectedOrderStatus.ChipColor = request.ChipColor; }

            await _context.SaveChangesAsync();

            return new UpdateOrderStatusResponse();
        }
    }
}
