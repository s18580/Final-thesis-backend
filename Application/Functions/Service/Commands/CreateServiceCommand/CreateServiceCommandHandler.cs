using Application.Services;
using MediatR;
using AutoMapper;

namespace Application.Functions.Service.Commands.CreateServiceCommand
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, CreateServiceResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateServiceCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateServiceResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateServiceValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateServiceResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newService = _mapper.Map<Domain.Models.Service>(request);

            await _context.Services.AddAsync(newService);
            await _context.SaveChangesAsync();

            return new CreateServiceResponse(newService.IdService);
        }
    }
}
