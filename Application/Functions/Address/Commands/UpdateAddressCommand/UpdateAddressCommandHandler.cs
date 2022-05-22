using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateAddressCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateAddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAddressValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateAddressResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedAddress = await _context.Addresses
                                                .Where(p => p.IdAddress == request.IdAddress)
                                                .SingleAsync();

            if (selectedAddress.Name != request.Name) { selectedAddress.Name = request.Name; }
            if (selectedAddress.Country != request.Country) { selectedAddress.Country = request.Country; }
            if (selectedAddress.City != request.City) { selectedAddress.City = request.City; }
            if (selectedAddress.StreetName != request.StreetName) { selectedAddress.StreetName = request.StreetName; }
            if (selectedAddress.StreetNumber != request.StreetNumber) { selectedAddress.StreetNumber = request.StreetNumber; }
            if (selectedAddress.ApartmentNumber != request.ApartmentNumber) { selectedAddress.ApartmentNumber = request.ApartmentNumber; }
            if (selectedAddress.PostCode != request.PostCode) { selectedAddress.PostCode = request.PostCode; }

            await _context.SaveChangesAsync();

            return new UpdateAddressResponse();
        }
    }
}
