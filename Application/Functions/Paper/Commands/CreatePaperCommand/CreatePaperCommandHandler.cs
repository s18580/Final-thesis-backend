using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Paper.Commands.CreatePaperCommand
{
    public class CreatePaperCommandHandler : IRequestHandler<CreatePaperCommand, CreatePaperResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreatePaperCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreatePaperResponse> Handle(CreatePaperCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePaperValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreatePaperResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newPaper = _mapper.Map<Domain.Models.Paper>(request);

            await _context.Papers.AddAsync(newPaper);
            await _context.SaveChangesAsync();

            return new CreatePaperResponse();
        }
    }
}
