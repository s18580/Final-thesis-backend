using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.ValuationPriceList.Commands.CreateValuationPriceListCommand
{
    public class CreateValuationPriceListCommandHandler : IRequestHandler<CreateValuationPriceListCommand, CreateValuationPriceListResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateValuationPriceListCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateValuationPriceListResponse> Handle(CreateValuationPriceListCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateValuationPriceListValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateValuationPriceListResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newValuationsPriceList = _mapper.Map<Domain.Models.ValuationPriceList>(request);

            await _context.ValuationPriceLists.AddAsync(newValuationsPriceList);
            await _context.SaveChangesAsync();

            return new CreateValuationPriceListResponse(newValuationsPriceList.IdValuation, newValuationsPriceList.IdPriceList);
        }
    }
}
