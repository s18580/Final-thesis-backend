using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeleteAddressResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteAddressCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteAddressResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteAddressValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteAddressResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var addressDelete = await _context.Addresses
                                              .Where(p => p.IdAddress == request.IdAddress)
                                              .SingleAsync();

            _context.Addresses.Remove(addressDelete);
            await _context.SaveChangesAsync();

            return new DeleteAddressResponse();
        }
    }
}
