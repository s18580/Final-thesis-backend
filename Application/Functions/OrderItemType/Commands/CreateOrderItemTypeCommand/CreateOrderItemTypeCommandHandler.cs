using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.OrderItemType.Commands.CreateOrderItemTypeCommand
{
    public class CreateOrderItemTypeCommandHandler : IRequestHandler<CreateOrderItemTypeCommand, CreateOrderItemTypeResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateOrderItemTypeCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateOrderItemTypeResponse> Handle(CreateOrderItemTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderItemTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateOrderItemTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newOrderItemType = _mapper.Map<Domain.Models.DictionaryModels.OrderItemType>(request);

            await _context.OrderItemTypes.AddAsync(newOrderItemType);
            await _context.SaveChangesAsync();

            return new CreateOrderItemTypeResponse();
        }
    }
}
