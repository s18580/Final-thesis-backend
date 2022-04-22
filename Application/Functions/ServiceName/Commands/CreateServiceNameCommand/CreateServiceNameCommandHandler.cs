using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.ServiceName.Commands.CreateServiceNameCommand
{
    public class CreateServiceNameCommandHandler : IRequestHandler<CreateServiceNameCommand, CreateServiceNameResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateServiceNameCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateServiceNameResponse> Handle(CreateServiceNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateServiceNameValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateServiceNameResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newServiceName = _mapper.Map<Domain.Models.DictionaryModels.ServiceName>(request);

            await _context.ServiceNames.AddAsync(newServiceName);
            await _context.SaveChangesAsync();

            return new CreateServiceNameResponse();
        }
    }
}
