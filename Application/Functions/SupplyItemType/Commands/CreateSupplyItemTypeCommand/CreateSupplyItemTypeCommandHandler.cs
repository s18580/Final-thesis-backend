using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand
{
    internal class CreateSupplyItemTypeCommandHandler : IRequestHandler<CreateSupplyItemTypeCommand, CreateSupplyItemTypeResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateSupplyItemTypeCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateSupplyItemTypeResponse> Handle(CreateSupplyItemTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSupplyItemTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateSupplyItemTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newSupplyItemType = _mapper.Map<Domain.Models.DictionaryModels.SupplyItemType>(request);

            await _context.SupplyItemTypes.AddAsync(newSupplyItemType);
            await _context.SaveChangesAsync();

            return new CreateSupplyItemTypeResponse();
        }
    }
}