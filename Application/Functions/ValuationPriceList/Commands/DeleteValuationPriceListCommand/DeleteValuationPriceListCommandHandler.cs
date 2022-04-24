using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ValuationPriceList.Commands.DeleteValuationPriceListCommand
{
    public class DeleteValuationPriceListCommandHandler : IRequestHandler<DeleteValuationPriceListCommand, DeleteValuationPriceListResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteValuationPriceListCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteValuationPriceListResponse> Handle(DeleteValuationPriceListCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteValuationPriceListValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteValuationPriceListResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var valuationPriceListsToDelete = await _context.ValuationPriceLists
                                                            .Where(p => p.IdValuation == request.IdValuation)
                                                            .Where(p => p.IdPriceList == request.IdPriceList)
                                                            .SingleAsync();

            _context.ValuationPriceLists.Remove(valuationPriceListsToDelete);
            await _context.SaveChangesAsync();

            return new DeleteValuationPriceListResponse();
        }
    }
}
