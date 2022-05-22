using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.DeliveriesAddresses.Commands.DeleteDeliveriesAddressesCommand
{
    public class DeleteDeliveriesAddressesCommandHandler : IRequestHandler<DeleteDeliveriesAddressesCommand, DeleteDeliveriesAddressesResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteDeliveriesAddressesCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteDeliveriesAddressesResponse> Handle(DeleteDeliveriesAddressesCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteDeliveriesAddressesValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteDeliveriesAddressesResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var deliveriesAddressesToDelete = await _context.DeliveriesAddresses
                                                            .Where(p => p.IdDeliveriesAddresses == request.IdDeliveriesAddresses)
                                                            .SingleAsync();

            _context.DeliveriesAddresses.Remove(deliveriesAddressesToDelete);
            await _context.SaveChangesAsync();

            return new DeleteDeliveriesAddressesResponse();
        }
    }
}
