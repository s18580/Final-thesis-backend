using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.PriceList.Commands.CreatePriceListCommand
{
    public class CreatePriceListCommandHandler : IRequestHandler<CreatePriceListCommand, CreatePriceListResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreatePriceListCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreatePriceListResponse> Handle(CreatePriceListCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePriceListValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreatePriceListResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newPriceList = _mapper.Map<Domain.Models.DictionaryModels.PriceList>(request);

            await _context.PriceLists.AddAsync(newPriceList);
            await _context.SaveChangesAsync();

            return new CreatePriceListResponse(newPriceList.IdPriceList);
        }
    }
}
