using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand
{
    public class CreateOrderStatusCommandHandler : IRequestHandler<CreateOrderStatusCommand, CreateOrderStatusResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateOrderStatusCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateOrderStatusResponse> Handle(CreateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderStatusCommandValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateOrderStatusResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newOrderStatus = _mapper.Map<Domain.Models.DictionaryModels.OrderStatus>(request);

            await _context.OrderStatuses.AddAsync(newOrderStatus);
            await _context.SaveChangesAsync();

            return new CreateOrderStatusResponse();
        }
    }
}
