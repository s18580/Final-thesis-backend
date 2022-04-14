using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.FileStatus.Commands.CreateFileStatusCommand
{
    public class CreateFileStatusCommandHandler : IRequestHandler<CreateFileStatusCommand, CreateFileStatusResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateFileStatusCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateFileStatusResponse> Handle(CreateFileStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFileStatusValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateFileStatusResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newFileStatus = _mapper.Map<Domain.Models.DictionaryModels.FileStatus>(request);

            await _context.FileStatuses.AddAsync(newFileStatus);
            await _context.SaveChangesAsync();

            return new CreateFileStatusResponse();
        }
    }
}
