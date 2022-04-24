using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Supply.Commands.CreateSupplyCommand
{
    public class CreateSupplyCommandHandler : IRequestHandler<CreateSupplyCommand, CreateSupplyResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateSupplyCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateSupplyResponse> Handle(CreateSupplyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSupplyValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateSupplyResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newSupply = _mapper.Map<Domain.Models.Supply>(request);

            await _context.Supplies.AddAsync(newSupply);
            await _context.SaveChangesAsync();

            return new CreateSupplyResponse(newSupply.IdSupply);
        }
    }
}
