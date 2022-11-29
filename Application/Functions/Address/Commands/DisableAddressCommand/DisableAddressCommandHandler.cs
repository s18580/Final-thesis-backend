using Application.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Application.Functions.Address.Commands.DisableAddressCommand
{
    public class DisableAddressCommandHandler : IRequestHandler<DisableAddressCommand, DisableAddressResponse>
    {
        private readonly IApplicationContext _context;

        public DisableAddressCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DisableAddressResponse> Handle(DisableAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new DisableAddressValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DisableAddressResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var address = await _context.Addresses.Where(p => p.IdAddress == request.Id).SingleAsync();
            address.IsDisabled = request.IsDisabled;

            await _context.SaveChangesAsync();

            return new DisableAddressResponse();
        }
    }
}
