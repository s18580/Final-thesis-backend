using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Color.Commands.CreateColorCommand
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreateColorResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateColorCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateColorValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateColorResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newColor = _mapper.Map<Domain.Models.Color>(request);

            await _context.Colors.AddAsync(newColor);
            await _context.SaveChangesAsync();

            return new CreateColorResponse();
        }
    }
}
