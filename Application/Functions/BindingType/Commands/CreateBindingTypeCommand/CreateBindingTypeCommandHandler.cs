using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.BindingType.Commands.CreateBindingTypeCommand
{
    public class CreateBindingTypeCommandHandler : IRequestHandler<CreateBindingTypeCommand, CreateBindingTypeResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateBindingTypeCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<CreateBindingTypeResponse> Handle(CreateBindingTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBindingTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateBindingTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newBindingType = _mapper.Map<Domain.Models.DictionaryModels.BindingType>(request);

            await _context.BindingTypes.AddAsync(newBindingType);
            await _context.SaveChangesAsync();

            return new CreateBindingTypeResponse(newBindingType.IdBindingType);
        }
    }
}
