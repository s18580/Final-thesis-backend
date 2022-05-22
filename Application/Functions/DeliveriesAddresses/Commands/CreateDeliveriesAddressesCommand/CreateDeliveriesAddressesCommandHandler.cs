using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.DeliveriesAddresses.Commands.CreateDeliveriesAddressesCommand
{
    public class CreateDeliveriesAddressesCommandHandler : IRequestHandler<CreateDeliveriesAddressesCommand, CreateDeliveriesAddressesResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateDeliveriesAddressesCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateDeliveriesAddressesResponse> Handle(CreateDeliveriesAddressesCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDeliveriesAddressesValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateDeliveriesAddressesResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newDeliveriesAddresses = _mapper.Map<Domain.Models.DeliveriesAddresses>(request);

            await _context.DeliveriesAddresses.AddAsync(newDeliveriesAddresses);
            await _context.SaveChangesAsync();

            return new CreateDeliveriesAddressesResponse(newDeliveriesAddresses.IdDeliveriesAddresses);
        }
    }
}
