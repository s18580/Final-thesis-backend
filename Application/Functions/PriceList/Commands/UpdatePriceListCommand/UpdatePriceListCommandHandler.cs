using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.PriceList.Commands.UpdatePriceListCommand
{
    public class UpdatePriceListCommandHandler : IRequestHandler<UpdatePriceListCommand, UpdatePriceListResponse>
    {
        private readonly IApplicationContext _context;

        public UpdatePriceListCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdatePriceListResponse> Handle(UpdatePriceListCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePriceListValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdatePriceListResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedPriceList = await _context.PriceLists
                                                  .Where(p => p.IdPriceList == request.IdPriceList)
                                                  .SingleAsync();

            if (selectedPriceList.Name != request.Name) { selectedPriceList.Name = request.Name; }
            if (selectedPriceList.Price != request.Price) { selectedPriceList.Price = request.Price; }

            await _context.SaveChangesAsync();

            return new UpdatePriceListResponse();
        }
    }
}
