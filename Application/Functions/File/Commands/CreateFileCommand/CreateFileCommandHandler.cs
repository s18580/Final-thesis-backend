using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.File.Commands.CreateFileCommand
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, CreateFileResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateFileCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateFileResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFileValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateFileResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newFile = _mapper.Map<Domain.Models.File>(request);
            newFile.AddedDate = DateTime.Now;

            await _context.Files.AddAsync(newFile);
            await _context.SaveChangesAsync();

            return new CreateFileResponse(newFile.IdFile);
        }
    }
}
