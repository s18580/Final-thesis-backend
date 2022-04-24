using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.OrderItem.Commands.CreateOrderItemCommand
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, CreateOrderItemResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateOrderItemCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateOrderItemResponse> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newOrderItem = _mapper.Map<Domain.Models.OrderItem>(request);

            await _context.OrderItems.AddAsync(newOrderItem);
            await _context.SaveChangesAsync();

            return new CreateOrderItemResponse(newOrderItem.IdOrderItem);
        }
    }
}
