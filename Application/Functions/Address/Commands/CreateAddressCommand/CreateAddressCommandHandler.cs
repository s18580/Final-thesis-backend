using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Address.Commands.CreateAddressCommand
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAddressValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateAddressResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newAddress = _mapper.Map<Domain.Models.Address>(request);

            await _context.Addresses.AddAsync(newAddress);
            await _context.SaveChangesAsync();

            return new CreateAddressResponse(newAddress.IdAddress);
        }
    }
}
