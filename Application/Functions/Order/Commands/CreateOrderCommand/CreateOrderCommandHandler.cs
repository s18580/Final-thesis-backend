using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateOrderResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newOrder = _mapper.Map<Domain.Models.Order>(request);

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return new CreateOrderResponse();
        }
    }
}
