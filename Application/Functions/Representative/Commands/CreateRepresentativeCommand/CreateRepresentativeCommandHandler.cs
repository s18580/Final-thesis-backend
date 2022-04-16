using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Representative.Commands.CreateRepresentativeCommand
{
    public class CreateRepresentativeCommandHandler : IRequestHandler<CreateRepresentativeCommand, CreateRepresentativeResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateRepresentativeCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateRepresentativeResponse> Handle(CreateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRepresentativeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateRepresentativeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newRepresentative = _mapper.Map<Domain.Models.Representative>(request);

            await _context.Representatives.AddAsync(newRepresentative);
            await _context.SaveChangesAsync();

            return new CreateRepresentativeResponse();
        }
    }
}