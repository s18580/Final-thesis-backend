using Application.Functions.DTOs.DTOsValidators;
using Application.Services;
using MediatR;

namespace Application.Functions.Supply.Commands.CreateSupplyWithAddressesCommand
{
    public class CreateSupplyWithAddressesCommandHandler : IRequestHandler<CreateSupplyWithAddressesCommand, CreateSupplyWithAddressesResponse>
    {
        private readonly IApplicationContext _context;

        public CreateSupplyWithAddressesCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<CreateSupplyWithAddressesResponse> Handle(CreateSupplyWithAddressesCommand request, CancellationToken cancellationToken)
        {
            // create validators
            var supplyValidator = new CreateSupplyWithAddressesValidator(_context);
            var addressValidator = new DeliveriesAddressesDTOValidator(_context);

            // validate data
            var supplyValidatorResult = await supplyValidator.ValidateAsync(request);
            if (!supplyValidatorResult.IsValid) return new CreateSupplyWithAddressesResponse(supplyValidatorResult, Responses.ResponseStatus.ValidationError);

            foreach (var address in request.DeliveriesAddresses)
            {
                var addressValidatorResult = await addressValidator.ValidateAsync(address);
                if (!addressValidatorResult.IsValid) return new CreateSupplyWithAddressesResponse(addressValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            // create objects in transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newSupply = new Domain.Models.Supply
                {
                    ItemDescription = request.ItemDescription,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    SupplyDate = request.SupplyDate,
                    IsReceived = request.IsReceived,
                    IdOrderItem = request.IdOrderItem,
                    IdRepresentative = request.IdRepresentative,
                    IdSupplyItemType = request.IdSupplyItemType,
                };

                await _context.Supplies.AddAsync(newSupply);
                await _context.SaveChangesAsync();

                foreach (var address in request.DeliveriesAddresses)
                {
                    var newAddress = new Domain.Models.DeliveriesAddresses
                    {
                        IdAddress = address.IdAddress,
                        IdOrder = null,
                        IdSupply = newSupply.IdSupply,
                    };

                    await _context.DeliveriesAddresses.AddAsync(newAddress);
                    await _context.SaveChangesAsync();
                }

                dbContextTransaction.Commit();
            }

            return new CreateSupplyWithAddressesResponse();
        }
    }
}
