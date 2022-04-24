using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Valuation.Commands.CreateValuationCommand
{
    public class CreateValuationCommandHandler : IRequestHandler<CreateValuationCommand, CreateValuationResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateValuationCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateValuationResponse> Handle(CreateValuationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newValuation = _mapper.Map<Domain.Models.Valuation>(request);

            await _context.Valuations.AddAsync(newValuation);
            await _context.SaveChangesAsync();

            return new CreateValuationResponse(newValuation.IdValuation);
        }
    }
}
