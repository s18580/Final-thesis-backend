using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand
{
    public class CreateDeliveryTypeCommandHandler : IRequestHandler<CreateDeliveryTypeCommand, CreateDeliveryTypeResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateDeliveryTypeCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateDeliveryTypeResponse> Handle(CreateDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDeliveryTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateDeliveryTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newDeliveryType = _mapper.Map<Domain.Models.DictionaryModels.DeliveryType>(request);

            await _context.DeliveryTypes.AddAsync(newDeliveryType);
            await _context.SaveChangesAsync();

            return new CreateDeliveryTypeResponse(newDeliveryType.IdDeliveryType);
        }
    }
}
