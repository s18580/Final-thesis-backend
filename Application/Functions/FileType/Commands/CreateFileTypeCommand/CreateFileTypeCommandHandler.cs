using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.FileType.Commands.CreateFileTypeCommand
{
    public class CreateFileTypeCommandHandler : IRequestHandler<CreateFileTypeCommand, CreateFileTypeResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateFileTypeCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateFileTypeResponse> Handle(CreateFileTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFileTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateFileTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newFileType = _mapper.Map<Domain.Models.DictionaryModels.FileType>(request);

            await _context.FileTypes.AddAsync(newFileType);
            await _context.SaveChangesAsync();

            return new CreateFileTypeResponse(newFileType.IdFileType);
        }
    }
}
